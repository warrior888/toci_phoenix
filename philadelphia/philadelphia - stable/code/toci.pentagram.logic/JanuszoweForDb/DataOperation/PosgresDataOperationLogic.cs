using System;
using AutoMapper;
using toci.pentagram.bll.Buisnessmodel;
using toci.pentagram.Dal;
using toci.pentagram.interfaces.buisnessModel;
using toci.pentagram.logic.FileReader.interfaces;
using toci.pentagram.logic.FileReader.logic;
using Toci.Db.Interfaces;

namespace toci.pentagram.logic.logicforDb.DataOperation
{
   public class PosgresDataOperationLogic: bll.dblogic.DbLogic, IGetOperationForApplicationTestBuisnesModel
    {

       public PosgresDataOperationLogic()
       {
           applicationTestsBuisnessModel = new ApplicationbuisnessModelForInsert();
           logic = new TextReaderLogic(new TextReader());
           model = new ApplicationTests();

       }
        public ITextReaderLogic logic { get; set; }
        public IModel model { get; set; }
        public IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel { get; set; }
       public int insert(IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel)
       {
           return DbHandle.InsertData(Mapper.Map<ApplicationTests>(applicationTestsBuisnessModel));
       }

       public int update(IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel)
       {
           throw new NotImplementedException();
       }

       public int delete(IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel)
       {
           throw new NotImplementedException();
       }

   

        public bool insert()
        {
          //  return DbHandle.InsertData(Mapper.Map<ApplicationTests>(typeof (ApplicationTestsBuisnessModel)));
            return false;
        }

        public int test()
        {
            applicationTestsBuisnessModel.Codesnipet = "asdsadsad";
          //  applicationTestsBuisnessModel.Id =5;
            applicationTestsBuisnessModel.Rightanswers = "knoc knock";


            return 0;


        }

       

       public int insert<T>(T stream)
       {
           return DbHandle.InsertData(Mapper.Map<ApplicationTests>(applicationTestsBuisnessModel));
       }



    }
}
