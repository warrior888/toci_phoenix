using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using DbCredentials.Certificate;
using DbCredentials.DbLogic.CredentialsModels;
using EncodingLib;
using ErrorsAndMessages.Exceptions;
using Toci.Db.DbVirtualization;
using Toci.Db.Interfaces;
using Toci.DigitalSignature.DigitalSignHandlers;

namespace DbCredentials.DbLogic
{
    public static class CredentialsExtMethods
    {
        static string path = CertConfig.certPath;
        static string pksecret = CertConfig.privateKeySecret;
        private const string InvalidData = "Invalid password!";
        private const bool PrivateParams = true;

        public static void EncryptModel(this Model model)
        {
            var projectsModel = (Projects) model;

            var secret = GetSecret(path, pksecret);
            var generateSecret = new GenerateSecret(secret);
            var hash = generateSecret.GetSecret();
            try
            {
                projectsModel.projectdata = new TociCrypting().EncryptStringAes(projectsModel.projectdata, secret, hash);
                projectsModel.hash = hash;
            }
            catch (Exception)
            {
                throw new WebApiTociApplicationException("Cannot encrypt project data in encrypt model.", null, (int)ApiErrors.WrongData);
            }
        }

        public static List<IModel> DecryptModels(this List<IModel> list)
        {
            //var projectsList = list.ConvertAll(new Converter<Model, Projects>(input => new Projects());
            var projectsList = list.Cast<Projects>().ToList();
            var secret = GetSecret(path, pksecret);
            try
            {
                foreach (var item in projectsList)
                {
                    var validateData = new VerifySecret(item.hash, secret);
                    item.projectdata = validateData.Verification()
                        ? new TociCrypting().DecryptStringAes(item.projectdata, secret, item.hash)
                        : InvalidData;
                }
                return projectsList.Cast<IModel>().ToList();
            }
            catch (Exception)
            {
                throw new WebApiTociApplicationException("Cannot decrypt project data in decrypt models.", null, (int)ApiErrors.WrongData);
            }
            
        }

        private static string GetSecret(string path, string password)
        {
            var sign = new Sign();
            byte[] pfxFile;
            try
            {
                pfxFile = File.ReadAllBytes(path);
            }
            catch (Exception)
            {
                throw new WebApiTociApplicationException("Unable to load pfx file", "litania do pfx", (int)ApiErrors.IdMissing);
            }

            SecureString securedPassword = new SecureString();
            foreach (var c in password.ToCharArray())
            {
                securedPassword.AppendChar(c);
            }
            try
            {
                var certificate = sign.PfxFileToCertificate(pfxFile, securedPassword);
                var privateKey = (RSACryptoServiceProvider) certificate.PrivateKey;
                return privateKey.ToXmlString(PrivateParams);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        
    }
}