using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models
{ 

public interface ICompiledXML
{
    Task<string> GetXML(List<WebExSingleUser> updatedWebExUsers, List<WebExUserColumns> lstColumns);
}



public class CompileXML : ICompiledXML
    {
        
        public CompileXML()
        {
            
        }

        #region " Public Method "

        public async Task<string> GetXML(List<WebExSingleUser> updatedWebExUsers, List<WebExUserColumns> lstColumns)
        {
            // Declarations
            string compiledXML = string.Empty;

            // loop through the columns present in the database 
            foreach (var dbTopNode in lstColumns.Where(r => r.IsHidden == false).OrderBy(r => r.TopNode).Select(r => r.TopNode).Distinct().ToList())
            {
                // Cmpile the XML structure with the current node 
                string currentXMLNode = CompiledNodeStructure(dbTopNode, string.Empty, false);
                // With the distinct top node get the values from the updated user list  
                foreach (var dbNestedNode in lstColumns.Where(r => r.TopNode == dbTopNode).OrderBy(r => r.NestedNode ).Select(r => r.NestedNode).Distinct())
                {
                    // loop through the row index 
                    foreach (var rowIndex in updatedWebExUsers.Where(r => r.TopNode == dbTopNode && IsAllowed(r.NestedNode, dbNestedNode) && (!(string.IsNullOrEmpty( r.FieldValue))) ).Select(r => r.FieldNodeIndex).Distinct())
                    {
                        // Add the nested node start structure 
                        currentXMLNode += CompiledNodeStructure(dbNestedNode, string.Empty, false);
                        // Get the row from the currently updated node 
                        foreach (var fieldNode in updatedWebExUsers.Where(r => r.TopNode == dbTopNode && IsAllowed(r.NestedNode, dbNestedNode) && r.FieldNodeIndex == rowIndex && (!(string.IsNullOrEmpty(r.FieldValue)))).ToList())
                        {
                            // Compile the field node Start 
                            currentXMLNode += CompiledNodeStructure(fieldNode.FieldNode, dbTopNode, false);

                            // Add the field value within 
                            currentXMLNode += fieldNode.FieldValue;

                            // Compile the field end 
                            currentXMLNode += CompiledNodeStructure(fieldNode.FieldNode, dbTopNode, true);

                        }
                        // Add the nested node End structure 
                        currentXMLNode += CompiledNodeStructure(dbNestedNode, string.Empty, true);
                    }
                }
                
                // Add the ending node for current topnode
                currentXMLNode += CompiledNodeStructure(dbTopNode, string.Empty, true);

                // Add the currently compiled structure into the main compiling structure 
                compiledXML += (string.IsNullOrEmpty(currentXMLNode)) ? string.Empty : currentXMLNode + "\r\n";
            }









            //// Declarations
            //string compiledXML = string.Empty;
            //Dictionary<string, int> header = new Dictionary<string, int>();
            //Dictionary<string, int> nested = new Dictionary<string, int>();


            //// loop through the top nodes distinct from the List we have 
            //foreach (var topNode in updatedWebExUsers.OrderBy(r => r.TopNode).Select( r=> r.TopNode).Distinct().ToList())
            //{
            //    // Cmpile the XML structure with the current node 
            //    string currentXMLNode = CompiledNodeStructure(topNode, string.Empty, false);
            //    // with the top node . Get the nested node and get distinct values 
            //    foreach (var nestedNode in updatedWebExUsers.Where(r => r.TopNode == topNode).OrderBy(r => r.NestedNode).Select(r => r.NestedNode).Distinct().ToList())
            //    {
            //        // Add the nested node start structure 
            //        currentXMLNode += CompiledNodeStructure(nestedNode, string.Empty, false);
            //        // with both top and nested nodes 
            //        foreach (var fieldNode in updatedWebExUsers.Where(r => r.TopNode == topNode && r.NestedNode == nestedNode).ToList())
            //        {
            //            // Compile the field node Start 
            //            currentXMLNode += CompiledNodeStructure(fieldNode.FieldNode, topNode, false);

            //            // Add the field value within 
            //            currentXMLNode += fieldNode.FieldValue;

            //            // Compile the field end 
            //            currentXMLNode += CompiledNodeStructure(fieldNode.FieldNode, topNode, true);

            //        }

            //        // Add the nested node End structure 
            //        currentXMLNode += CompiledNodeStructure(nestedNode, string.Empty, true);
            //    }
            //    // Add the ending node for current topnode
            //    currentXMLNode += CompiledNodeStructure(topNode, string.Empty, true);

            //    // Add the currently compiled structure into the main compiling structure 
            //    compiledXML += ( string.IsNullOrEmpty(currentXMLNode)) ? string.Empty : currentXMLNode + "\r\n";

            //}


           

            // Return the values 
            return compiledXML;
        }

        #endregion

        #region " Private Methods "
        private string CompiledNodeStructure(string nodeName, string checkNode, bool isEnd)
        {
            try
            {
                // Declarations 
                string nodeCompiled = string.Empty;
                string endStr = ((isEnd) ? "/" : string.Empty );
                if (!(string.IsNullOrEmpty(nodeName)))
                {
                    // check if the field node and top node are not same 
                    if (!(nodeName == checkNode))
                    {

                        nodeCompiled = string.Format("<{0}{1}>", endStr,nodeName);
                    }
                }


                // return the values 
                return nodeCompiled;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool IsAllowed(string dbValue, string checkValue)
        {
            string value = string.IsNullOrEmpty(dbValue) ? string.Empty : dbValue;
            string value2 = string.IsNullOrEmpty(checkValue) ? string.Empty : checkValue;
            if (value.ToLower() == value2.ToLower())
                return true;
            else
                return false;
        }

        #endregion



    }
}
