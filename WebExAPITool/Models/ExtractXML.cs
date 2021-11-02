using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using WebExAPITool.Models.DB;

namespace WebExAPITool.Models
{
    public class ExtractXML
    {

        public ExtractXML()
        {

        }


        #region " Public Methods "

        #region " PrepareList "

        public  List<WebExSingleUser> PrepareList(List<WebExUserColumns> listColumn, int counter)
        {
            var filledList = new List<WebExSingleUser>();
            int rowCount = 1;
            foreach (var item in listColumn.ToList())
            {
                var newRow = new WebExSingleUser()
                {
                    FieldNode = item.FieldName,
                     ColumnID = item.ColumnId ,
                    IndexID = counter,
                    RowID = rowCount,
                    FieldValue = string.Empty,
                    NestedNode = (string.IsNullOrEmpty(item.NestedNode)) ? string.Empty : item.NestedNode,
                    TopNode = item.TopNode,
                    IsHidden = item.IsHidden,
                    IsComparable= item.IsComparable,
                     SettingLabel = item.SettingLabel,
                      Notes = item.Notes,
                    FieldNodeIndex = 0

                };

                // Add the row in the filled List 
                filledList.Add(newRow);
                rowCount++;
            }

            return filledList;
        }

        #endregion


        #region " AddNodeToTuple "
        public  void AddNodeToTuple(XmlNode elementNode, Dictionary<int, string> names, int counter, List<WebExSingleUser> list, List<WebExUserColumns> listColumns)
        {
            try
            {

                // Check if the element node has child nodes 
                if (elementNode.FirstChild != null && elementNode.FirstChild.NodeType == XmlNodeType.Element)
                {
                    // Get the loop through 
                    foreach (XmlNode node in elementNode.ChildNodes)
                    {
                        // add the nested element node
                        // names.Add(names.Count(), node.LocalName);
                        // add the values 
                        AddNodeToTuple(node, names, counter, list, listColumns);
                    }
                }
                else
                {

                    // Get the current nested node 
                    string nestedNode = elementNode.ParentNode.LocalName.ToString();
                    if (nestedNode.ToLower() == names[0].ToLower() || nestedNode.ToLower() == "bodyContent".ToLower())
                        nestedNode = string.Empty;

                    // Get the compiled nested nodes till the first node 
                    string intermediateNestedNode = string.Empty;
                    if (!(string.IsNullOrEmpty(nestedNode)))
                        intermediateNestedNode = GetIntermediateNode(elementNode.ParentNode.ParentNode, names[0].ToString(), intermediateNestedNode);


                    // Get the Top node 
                    string topNode = names[0].ToString();

                    // Get the current node 
                    string currentNode = elementNode.LocalName;




                    // get the row form the list
                    var unlist = list.Where(m => isAllowed(m.TopNode, topNode) && isAllowed(m.NestedNode, intermediateNestedNode + nestedNode) && isAllowed(m.FieldNode, currentNode));
                    var foundItem = unlist.FirstOrDefault();
                    if (foundItem != null)
                    {
                        // Check when the node is zero then update the row 
                        if (foundItem.FieldNodeIndex > 0)
                        {
                            // Add the new row in the list 
                            var newRow = new WebExSingleUser()
                            {
                                FieldNode = currentNode,
                                ColumnID = foundItem.ColumnID,
                                IndexID = counter,
                                RowID = list.Count(),
                                FieldValue = elementNode.InnerText,
                                NestedNode = intermediateNestedNode + nestedNode,
                                TopNode = topNode,
                                IsHidden = foundItem.IsHidden,
                                 IsComparable =   foundItem.IsComparable,
                                FieldNodeIndex = (foundItem.FieldNodeIndex + 1),
                                Notes = foundItem.Notes,
                                SettingLabel = foundItem.SettingLabel


                            };

                            // Add the row in the filled List 
                            list.Add(newRow);
                        }
                        else
                        {
                            // Update the existing row 
                            foundItem.FieldValue = elementNode.InnerText;
                            foundItem.FieldNodeIndex = 1;
                        }
                    }



                    //// Get the row from the database 
                    //var foundItem = listColumns.Find(m => isAllowed(m.TopNode, topNode) && isAllowed(m.NestedNode, nestedNode) && isAllowed(m.FieldName, currentNode));

                    //// check when we have row associated in the databse for the columns 
                    //if (!(foundItem == null))
                    //{
                    //    list.Add(new WebExSingleUser()
                    //    {
                    //        RowID = (list.Count() + 1),
                    //        TopNode = foundItem.TopNode,
                    //        NestedNode = foundItem.NestedNode,
                    //        FieldNode = foundItem.FieldName,
                    //        FieldValue = elementNode.InnerText,
                    //        IndexID = counter

                    //    });

                    //}

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private string GetIntermediateNode(XmlNode elementNode, string topNode, string intermediateNestedNode)
        {
            try
            {

                // Check when the current node is equal to top node 
                if (elementNode.LocalName != topNode)
                {
                    intermediateNestedNode += elementNode.LocalName + "/";
                    GetIntermediateNode(elementNode.ParentNode, topNode, intermediateNestedNode);
                }

                return intermediateNestedNode;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static bool isAllowed(string dbValue, string elementValue)
        {
            //if (string.IsNullOrEmpty(dbValue))
            //    return true;


            if (dbValue.ToLower() == elementValue.ToLower())
                return true;
            else
                return false;
        }

        #endregion


        #endregion
    }
}
