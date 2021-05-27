using AcmeWidget.Models;
using AcmeWidget.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWidget.Interface
{
    public interface IRegistraionService
    {
        Task<Message<bool>> RegisterContact(Contact contact);
    }
}
