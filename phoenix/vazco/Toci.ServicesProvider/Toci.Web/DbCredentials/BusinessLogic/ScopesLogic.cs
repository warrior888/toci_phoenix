﻿using System;
using System.Collections.Generic;
using System.Linq;
using DbCredentials.Config;
using DbCredentials.DbLogic;
using DbCredentials.DbLogic.CredentialsModels;
using ErrorsAndMessages.Exceptions;
using Toci.Utilities.Common.Exceptions;

namespace DbCredentials.BusinessLogic
{
    public class ScopesLogic
    {
        private const int notSaved = 0;
        private const bool exist = true;
        readonly DbQuery dbQuery;

        public ScopesLogic(DbConfig dbConfig)
        {
            dbQuery = new DbQuery(dbConfig);
        }
        public bool AddScope(Scopes model)
        {
            if (IsScopeExist(model))
            {
                return exist;
            }
            try
            {
                return dbQuery.Save(model) != notSaved;
            }
            catch (TociApplicationException ex)
            {
                throw new WebApiTociApplicationException("Cannot add scope.", null, (int)ApiErrors.WrongData, ex);
            }
        }

        public bool IsScopeExist(Scopes model)
        {
            List<Scopes> list;
            try
            {
                list = dbQuery.Load(model).Cast<Scopes>().ToList();
                return list.Any(item => item.scopename.Equals(model.scopename));
            }
            catch (Exception)
            {
                throw new WebApiTociApplicationException("Cannot load scope list.", null, (int)ApiErrors.WrongData);
            }
            
        }

        public Scopes GetScopeId(Scopes model)
        {
            AddScope(model);

            var list = dbQuery.Load(model).Cast<Scopes>().ToList();

            foreach (var item in list.Where(item => item.scopename.Equals(model.scopename)))
            {
                model.scopeid = item.scopeid;
                return model;
            }

            //list.Any(item => item.scopename.Equals(model.scopename) model.scopeid = item.scopeid);
            return model;     
        }

        public List<Scopes> GetScopesId(List<Scopes> scopesList)
        {
            return scopesList.Select(GetScopeId).ToList();
        }
        public string GetScopesName(int scopeId)
        {
            var model = new Scopes {scopeid = scopeId};
            var list = dbQuery.Load(model).Cast<Scopes>().ToList();
            return (from item in list where item.scopeid == scopeId select item.scopename).FirstOrDefault();
        }
        //public List<Scopes> LoadScopes(Scopes model)
        //{
        //    return dbQuery.Load(model).Cast<Scopes>().ToList();
        //}

        //public bool DeleteScope(Scopes model)
        //{
        //    if (!IsScopeExist(model))
        //    {
        //        throw new WebApiTociApplicationException("Scope does not exist. ", null, (int)ApiErrors.DataMissing);
        //    }
        //    try
        //    {
        //        dbQuery.Delete(model, Scopes.SCOPENAME);
        //        return true;
        //    }
        //    catch (TociApplicationException ex)
        //    {
        //        throw new WebApiTociApplicationException("Cannot delete scope. ", null, (int)ApiErrors.WrongData, ex);
        //    }
        //}

        //public bool UpdateScope(Scopes model)
        //{
        //    if (!IsScopeExist(model))
        //    {
        //        throw new WebApiTociApplicationException("Scope does not exist. ", null, (int)ApiErrors.DataMissing);
        //    }
        //    try
        //    {
                
        //        dbQuery.Update(GetScopeId(model), Scopes.SCOPEID);
        //        return true;
        //    }
        //    catch (TociApplicationException ex)
        //    {
        //        throw new WebApiTociApplicationException("Cannot update scope. ", null, (int)ApiErrors.WrongData, ex);
        //    }
        //}
    }
}