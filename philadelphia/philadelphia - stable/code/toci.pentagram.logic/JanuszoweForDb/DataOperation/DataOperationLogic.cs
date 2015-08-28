using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toci.pentagram.bll.Buisnessmodel;
using toci.pentagram.bll.dblogic;
using toci.pentagram.interfaces;
using toci.pentagram.interfaces.buisnessModel;
using toci.pentagram.logic.logicforDb;
using toci.pentagram.logic.logicforDb.DataOperation;
using Toci.Db.DbVirtualization.PostgreSqlQuery;
using Toci.Db.Interfaces;

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
