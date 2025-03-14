﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using System.Net;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security;
//using System.Web.Script.Serialization;
using System.ComponentModel;
using System.Runtime.InteropServices;
using RestSharp;
using System.Web;

using WebExAPITool.Intersight.Model;
using System.Threading.Tasks;

namespace WebExAPITool.Intersight.Client
{
    public class IntersightApiClient:ApiClient
    {
        string private_key_file;
        string api_key_id;
        string digest_algorithm;
        string host;
        const String pemprivheader = "-----BEGIN RSA PRIVATE KEY-----";
        const String pemprivfooter = "-----END RSA PRIVATE KEY-----";
        const String pempubheader = "-----BEGIN PUBLIC KEY-----";
        const String pempubfooter = "-----END PUBLIC KEY-----";
        const String pemp8header = "-----BEGIN PRIVATE KEY-----";
        const String pemp8footer = "-----END PRIVATE KEY-----";
        const String pemp8encheader = "-----BEGIN ENCRYPTED PRIVATE KEY-----";
        const String pemp8encfooter = "-----END ENCRYPTED PRIVATE KEY-----";
        public IntersightApiClient(string _host, string private_key, string _api_key_id) : base(_host)
        {
             host = _host;
             private_key_file = private_key;
             api_key_id = _api_key_id;
             digest_algorithm = "rsa-sha256";
	     ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }


        static SecureString GetSecPswd(String prompt)
        {
            SecureString password = new SecureString();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Magenta;

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return password;
                }
                else if (cki.Key == ConsoleKey.Backspace)
                {
                    // remove the last asterisk from the screen..
                    if (password.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        password.RemoveAt(password.Length - 1);
                    }
                }
                else if (cki.Key == ConsoleKey.Escape)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    return password;
                }
                else if (Char.IsLetterOrDigit(cki.KeyChar) || Char.IsSymbol(cki.KeyChar))
                {
                    if (password.Length < 20)
                    {
                        password.AppendChar(cki.KeyChar);
                    }
                    else
                    {
                        Console.Beep();
                    }
                }
                else
                {
                    Console.Beep();
                }
            }
        }

        static bool CompareBytearrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;
            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i])
                    return false;
                i++;
            }
            return true;
        }

        static void showBytes(String info, byte[] data)
        {
            Console.WriteLine("{0}  [{1} bytes]", info, data.Length);
            for (int i = 1; i <= data.Length; i++)
            {
                Console.Write("{0:X2}  ", data[i - 1]);
                if (i % 16 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }

        static byte[] GetOpenSSL3deskey(byte[] salt, SecureString secpswd, int count, int miter)
        {
            IntPtr unmanagedPswd = IntPtr.Zero;
            int HASHLENGTH = 16;    //MD5 bytes
            byte[] keymaterial = new byte[HASHLENGTH * miter];     //to store contatenated Mi hashed results


            byte[] psbytes = new byte[secpswd.Length];
            unmanagedPswd = Marshal.SecureStringToGlobalAllocAnsi(secpswd);
            Marshal.Copy(unmanagedPswd, psbytes, 0, psbytes.Length);
            Marshal.ZeroFreeGlobalAllocAnsi(unmanagedPswd);

            //UTF8Encoding utf8 = new UTF8Encoding();
            //byte[] psbytes = utf8.GetBytes(pswd);

            // --- contatenate salt and pswd bytes into fixed data array ---
            byte[] data00 = new byte[psbytes.Length + salt.Length];
            Array.Copy(psbytes, data00, psbytes.Length);      //copy the pswd bytes
            Array.Copy(salt, 0, data00, psbytes.Length, salt.Length); //concatenate the salt bytes

            // ---- do multi-hashing and contatenate results  D1, D2 ..  into keymaterial bytes ----
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = null;
            byte[] hashtarget = new byte[HASHLENGTH + data00.Length];   //fixed length initial hashtarget

            for (int j = 0; j < miter; j++)
            {
                // ----  Now hash consecutively for count times ------
                if (j == 0)
                    result = data00;    //initialize 
                else
                {
                    Array.Copy(result, hashtarget, result.Length);
                    Array.Copy(data00, 0, hashtarget, result.Length, data00.Length);
                    result = hashtarget;
                    //Console.WriteLine("Updated new initial hash target:") ;
                    //showBytes(result) ;
                }

                for (int i = 0; i < count; i++)
                    result = md5.ComputeHash(result);
                Array.Copy(result, 0, keymaterial, j * HASHLENGTH, result.Length);  //contatenate to keymaterial
            }
            //showBytes("Final key material", keymaterial);
            byte[] deskey = new byte[24];
            Array.Copy(keymaterial, deskey, deskey.Length);

            Array.Clear(psbytes, 0, psbytes.Length);
            Array.Clear(data00, 0, data00.Length);
            Array.Clear(result, 0, result.Length);
            Array.Clear(hashtarget, 0, hashtarget.Length);
            Array.Clear(keymaterial, 0, keymaterial.Length);

            return deskey;
        }
        static byte[] DecryptKey(byte[] cipherData, byte[] desKey, byte[] IV)
        {
            MemoryStream memst = new MemoryStream();
            TripleDES alg = TripleDES.Create();
            alg.Key = desKey;
            alg.IV = IV;
            try
            {
                CryptoStream cs = new CryptoStream(memst, alg.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cipherData, 0, cipherData.Length);
                cs.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                return null;
            }
            byte[] decryptedData = memst.ToArray();
            return decryptedData;
        }
        static byte[] DecodeOpenSSLPrivateKey(String instr)
        {
            const String pemprivheader = "-----BEGIN RSA PRIVATE KEY-----";
            const String pemprivfooter = "-----END RSA PRIVATE KEY-----";
            String pemstr = instr.Trim();
            byte[] binkey;
            if (!pemstr.StartsWith(pemprivheader) || !pemstr.EndsWith(pemprivfooter))
                return null;

            StringBuilder sb = new StringBuilder(pemstr);
            sb.Replace(pemprivheader, "");  //remove headers/footers, if present
            sb.Replace(pemprivfooter, "");

            String pvkstr = sb.ToString().Trim();   //get string after removing leading/trailing whitespace

            try
            {        // if there are no PEM encryption info lines, this is an UNencrypted PEM private key
                binkey = Convert.FromBase64String(pvkstr);
                return binkey;
            }
            catch (System.FormatException)
            {       //if can't b64 decode, it must be an encrypted private key
                //Console.WriteLine("Not an unencrypted OpenSSL PEM private key");  
            }

            StringReader str = new StringReader(pvkstr);

            //-------- read PEM encryption info. lines and extract salt -----
            if (!str.ReadLine().StartsWith("Proc-Type: 4,ENCRYPTED"))
                return null;
            String saltline = str.ReadLine();
            if (!saltline.StartsWith("DEK-Info: DES-EDE3-CBC,"))
                return null;
            String saltstr = saltline.Substring(saltline.IndexOf(",") + 1).Trim();
            byte[] salt = new byte[saltstr.Length / 2];
            for (int i = 0; i < salt.Length; i++)
                salt[i] = Convert.ToByte(saltstr.Substring(i * 2, 2), 16);
            if (!(str.ReadLine() == ""))
                return null;

            //------ remaining b64 data is encrypted RSA key ----
            String encryptedstr = str.ReadToEnd();

            try
            {   //should have b64 encrypted RSA key now
                binkey = Convert.FromBase64String(encryptedstr);
            }
            catch (System.FormatException)
            {  // bad b64 data.
                return null;
            }

            //------ Get the 3DES 24 byte key using PDK used by OpenSSL ----

            SecureString despswd = GetSecPswd("Enter password to derive 3DES key==>");
            //Console.Write("\nEnter password to derive 3DES key: ");
            //String pswd = Console.ReadLine();
            byte[] deskey = GetOpenSSL3deskey(salt, despswd, 1, 2);    // count=1 (for OpenSSL implementation); 2 iterations to get at least 24 bytes
            if (deskey == null)
                return null;
            //showBytes("3DES key", deskey) ;

            //------ Decrypt the encrypted 3des-encrypted RSA private key ------
            byte[] rsakey = DecryptKey(binkey, deskey, salt); //OpenSSL uses salt value in PEM header also as 3DES IV
            if (rsakey != null)
                return rsakey;  //we have a decrypted RSA private key
            else
            {
                Console.WriteLine("Failed to decrypt RSA private key; probably wrong password.");
                return null;
            }
        }

        static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            MemoryStream mem = new MemoryStream(privkey);
            BinaryReader binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt = 0;
            ushort twobytes = 0;
            int elems = 0;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                    binr.ReadByte();    //advance 1 byte
                else if (twobytes == 0x8230)
                    binr.ReadInt16();   //advance 2 bytes
                else
                    return null;

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                    return null;
                bt = binr.ReadByte();
                if (bt != 0x00)
                    return null;


                //------  all private key components are Integer sequences ----
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                /*Console.WriteLine("showing components .");
                if (true)
                {
                    showBytes("\nModulus", MODULUS);
                    showBytes("\nExponent", E);
                    showBytes("\nD", D);
                    showBytes("\nP", P);
                    showBytes("\nQ", Q);
                    showBytes("\nDP", DP);
                    showBytes("\nDQ", DQ);
                    showBytes("\nIQ", IQ);
                }*/

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSAParameters RSAparams = new RSAParameters();
                RSAparams.Modulus = MODULUS;
                RSAparams.Exponent = E;
                RSAparams.D = D;
                RSAparams.P = P;
                RSAparams.Q = Q;
                RSAparams.DP = DP;
                RSAparams.DQ = DQ;
                RSAparams.InverseQ = IQ;
                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally { binr.Close(); }
        }

        private static int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02)		//expect integer
                return 0;
            bt = binr.ReadByte();

            if (bt == 0x81)
                count = binr.ReadByte();	// data size in next byte
            else
                if (bt == 0x82)
                {
                    highbyte = binr.ReadByte();	// data size in next 2 bytes
                    lowbyte = binr.ReadByte();
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                    count = BitConverter.ToInt32(modint, 0);
                }
                else
                {
                    count = bt;		// we already have the data size
                }
            while (binr.ReadByte() == 0x00)
            {	//remove high order zeros in data
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            //last ReadByte wasn't a removed zero, so back up a byte
            return count;
        }
        public static RSACryptoServiceProvider GetRSAProviderFromPemFile(String pemfile)
        {
            bool isPrivateKeyFile = true;
            string pemstr = File.ReadAllText(pemfile).Trim();
            if (pemstr.StartsWith(pempubheader) && pemstr.EndsWith(pempubfooter))
                isPrivateKeyFile = false;

            byte[] pemkey = null;
            if (isPrivateKeyFile)
                pemkey = DecodeOpenSSLPrivateKey(pemstr);


            if (pemkey == null)
                return null;

            if (isPrivateKeyFile)
                return DecodeRSAPrivateKey(pemkey);

            return null;
        }
        public async  Task<Object> CallApi(
            String path, RestSharp.Method method, Dictionary<String, String> queryParams, Object postBody,
            Dictionary<String, String> headerParams, Dictionary<String, String> formParams,
            Dictionary<String, FileParameter> fileParams, Dictionary<String, String> pathParams,
            String contentType)
        {

            
            foreach (var x in pathParams)
            {
                path = path.Replace("{" + string.Format("{0}", x.Key) + "}", x.Value);
            }

            headerParams.Clear();
            prepare_auth_header(path, method, postBody, queryParams);
            
            headerParams.Add("Content-Type", "application/json");
            headerParams.Add("Accept", "application/json");

            foreach (var field in Configuration.DefaultHeader)
            {
                if (!headerParams.ContainsKey(field.Key))
                {
                    headerParams.Add(field.Key, field.Value);
                }
            }
           
            foreach (var x in queryParams)
            {
                string key = x.Key;
                string value = x.Value;
            }
             
            return await base.CallApi(path, method, queryParams, postBody, headerParams, formParams, fileParams, pathParams, contentType);
        }

        public byte[] get_sha256_digest(string data)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(data);                   
            byte[] hash = sha256.ComputeHash(bytes);
            return hash;
        }

        public string get_rsasig_b64encode(string private_key_path,byte[] digest)
        {
            RSACryptoServiceProvider cipher = new RSACryptoServiceProvider();
            cipher = GetRSAProviderFromPemFile(private_key_path);
            RSAPKCS1SignatureFormatter RSAFormatter = new RSAPKCS1SignatureFormatter(cipher);
            RSAFormatter.SetHashAlgorithm("SHA256");
            byte[] signedHash = RSAFormatter.CreateSignature(digest);
            return Convert.ToBase64String(signedHash);
        }

        public string prepare_str_to_sign(string req_tgt,Dictionary<String, String> hdrs)
        {
            string ss = "";
            ss = ss + "(request-target): " + req_tgt.ToLower() + "\n";
            int length = hdrs.Count;
            int i = 0;
            foreach(var item in hdrs)
            {
                ss = ss + item.Key.ToLower() + ": " + item.Value;
                if (i < length-1)
                   {
                       ss = ss + "\n";
                   } 
                i += 1;
            }
            return ss;
        }

        public string get_auth_header(Dictionary<String, String> hdrs,string signed_msg)
        {
            byte[] data = Convert.FromBase64String(signed_msg);

            string auth_str = "";
            auth_str = auth_str + "Signature";
            auth_str = auth_str + " " + "keyId=\"" + api_key_id + "\"," + "algorithm=\"" +  digest_algorithm + "\"," + "headers=\"(request-target)";
            foreach (var item in hdrs)
            {
                auth_str = auth_str + " " +item.Key.ToLower();
            }
            auth_str = auth_str + "\"";
            auth_str = auth_str + "," + "signature=\"" + signed_msg + "\"";// byte to string
            return auth_str;
        }

        public void prepare_auth_header(string resource_path, RestSharp.Method method, Object body, Dictionary<String, String> query_params)
        {
            string _body;
            if (body == null)
            {
                _body = "";
            }else
            {
                _body = body.ToString();
            }

            Uri myUri = new Uri(host);
            string target_host = myUri.Host;
            string target_path = myUri.LocalPath;
            string request_target = method.ToString() + " " + target_path  + resource_path;

            if (query_params != null && query_params.Count > 0)
            {
                string raw_query = "";
                int count = 0;

                foreach (var item in query_params)
                {
                    count++;
                    if (count == 1)
                    {
                        raw_query = item.Key.ToString() + "=" + item.Value.ToString();
                        //break;
                    }
                    else
                    {
                        raw_query = raw_query + "&" + item.Key.ToString() + "=" + item.Value.ToString();
                    }
                }

                string str = "";
                try
                {
                    str = System.Web.HttpUtility.UrlEncode(raw_query);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception : " + ex);
                }
                //Console.WriteLine("new URL " + request_target + "?" + str);
                //raw_query = raw_query.Replace(" ", "%20");
                //raw_query = raw_query.Replace("$", "%24");
                //raw_query = raw_query.Replace("'", "%27");
                //request_target += "?" + raw_query;
                str = str.Replace("+","%20");
                str = str.Replace("%3d", "=");
                str = str.Replace("%26", "&");
                request_target = request_target + "?" + str;
            }

            DateTime now = DateTime.Now;
            DateTime date1 = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second);
            string cdate = date1.ToUniversalTime().ToString("r");
           
            byte[] body_digest = get_sha256_digest(_body);
            Dictionary<String, String> headers = new Dictionary<string, string>();
            
            headers.Add("Date",cdate);
            headers.Add("Host", target_host);
            headers.Add("Content-Type", "application/json");
            headers.Add("Digest", string.Format("SHA-256={0}", Convert.ToBase64String(body_digest)));
            
            string string_to_sign = prepare_str_to_sign(request_target, headers);

            byte[] digest = get_sha256_digest(string_to_sign);

            string b64_signed_msg = get_rsasig_b64encode(private_key_file, digest);
            string auth_header = get_auth_header(headers, b64_signed_msg);

            Configuration.AddDefaultHeader("Date", string.Format("{0}",(cdate)));
            Configuration.AddDefaultHeader("Host", string.Format("{0}", (target_host)));
            Configuration.AddDefaultHeader("Digest", string.Format("SHA-256={0}", Convert.ToBase64String(body_digest)));
            Configuration.AddDefaultHeader("Authorization", string.Format("{0}", (auth_header)));

             

            ServicePointManager.ServerCertificateValidationCallback = new
            RemoteCertificateValidationCallback(
               delegate { return true; }
            );
        }
    }
}
