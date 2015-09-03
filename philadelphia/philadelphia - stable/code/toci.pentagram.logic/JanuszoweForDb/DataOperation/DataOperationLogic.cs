using System.Collections.Generic;
using toci.pentagram.logic.logicforDb;

namespace toci.pentagram.logic.DbLogic.PostgresInsert
{
  public  class DataOperationLogic:IDataOperatioonLogic
    {   
       
      protected IGetOperationForApplicationTestBuisnesModel _operations;

      protected Dictionary<string, int> DictionaryOperation;
     // IApplicationtestBuisnessModelforInsert a = new ApplicationbuisnessModelForInsert();
      public DataOperationLogic(IGetOperationForApplicationTestBuisnesModel operation)
      {     
         
          _operations = operation;
          DictionaryOperation = new Dictionary<string, int>
          { 
              {"insert",_operations.insert(_operations.applicationTestsBuisnessModel)}
             
       
          };
      }

     


      public int DoOperation(string nameOperation, string path)
      {
          _operations.applicationTestsBuisnessModel.Codesnipet = _operations.logic.GetValue(path);

          return 0;


      }
    }
}
