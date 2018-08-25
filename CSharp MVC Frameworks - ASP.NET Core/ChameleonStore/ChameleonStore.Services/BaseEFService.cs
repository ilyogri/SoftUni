using ChameleonStore.Web.Data;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ChameleonStore.Services
{
    public abstract class BaseEFService
    {
        protected BaseEFService(
            ChameleonStoreContext context,
            IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        protected ChameleonStoreContext Context { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
