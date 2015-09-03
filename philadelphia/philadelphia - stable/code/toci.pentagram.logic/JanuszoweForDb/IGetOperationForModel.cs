using toci.pentagram.interfaces.buisnessModel;
using toci.pentagram.logic.FileReader.interfaces;
using Toci.Db.Interfaces;

namespace toci.pentagram.logic.logicforDb
{
    public interface IGetOperationForApplicationTestBuisnesModel
    {
      ITextReaderLogic logic { get; set; }
        IModel model { get; set; }
       IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel { get; set; }
      int insert(IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel);
       int update(IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel);
       int delete(IApplicationtestBuisnessModelforInsert applicationTestsBuisnessModel);
      
       


    }
}