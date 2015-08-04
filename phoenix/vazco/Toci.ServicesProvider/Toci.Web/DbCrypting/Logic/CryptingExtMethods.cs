using System;
using System.Collections.Generic;
using EncodingLib;
using Toci.Db.DbVirtualization;

namespace DbCrypting.Logic
{
    public static class CryptingExtMethods
    {


        public static void EncryptModel(this VazcoTable model, string secret)
        {

            var GenerateSecret = new GenerateSecret(secret);
            var hash = GenerateSecret.GetSecret();
            model.data = new TociCrypting().EncryptStringAes(model.data, secret, hash);
            model.hash = hash;

        }
        public static void DecryptDbModels(this List<VazcoTable> list, string secret)
        {

            foreach (var item in list)
            {
                item.data = new TociCrypting().DecryptStringAes(item.data, secret, item.hash);
            }

        }
        public static void FillAddInModel(this VazcoTable itemModel)//, DbModel model)
        {
            itemModel.name = DbUtils.GetUserNick();
            //itemModel.data =        model.data;
            itemModel.addingTime = DateTime.Now;
            // itemModel.hash =        model.hash;
        }
        /// <summary>
        /// to delete \/
        /// </summary>
        /// <param name="model"></param>
        /// <param name="secret"></param>
        public static void EncryptModel(this DbModel model, string secret)
        {

            var GenerateSecret = new GenerateSecret(secret);
            var hash = GenerateSecret.GetSecret();
            model.data = new TociCrypting().EncryptStringAes(model.data, secret, hash);
            model.hash = hash;

        }
        public static void DecryptDbModels(this List<DbModel> list, string secret)
        {

            foreach (var item in list)
            {
                item.data = new TociCrypting().DecryptStringAes(item.data, secret, item.hash);
            }

        }
       
    }
}