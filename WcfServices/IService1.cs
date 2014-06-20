using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IContactService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeContact GetDataUsingDataContract(CompositeContact composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeContact
    {        
        private int? _id;
        private string _fname;
        private string _lname;
        private string _company;
        private string _region;

        [DataMember]
        public int? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        [DataMember]
        public string Region
        {
            get
            {
                return this._region;
            }
            set
            {
                this._region = value;
            }
        }

        [DataMember]
        public string Company
        {
            get
            {
                return this._company;
            }
            set
            {
                this._company = value;
            }
        }

        [DataMember]
        public string LName
        {
            get
            {
                return this._lname;
            }
            set
            {
                this._lname = value;
            }
        }

        [DataMember]
        public string FName
        {
            get
            {
                return this._fname;
            }
            set
            {
                this._fname = value;
            }
        }
    }
}
