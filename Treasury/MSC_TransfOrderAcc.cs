using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XyloCode.Tools.Treasury
{
    [XmlRoot(Namespace = "http://www.roskazna.ru/eb/domain/MSC_TransfOrderAcc/formular", IsNullable = true)]
    public class MSC_TransfOrderAcc
    {
        public string Name { get; set; }


        [XmlElement(Namespace = "")]
        public Guid? AccDoc_Guid { get; set; }

        [XmlElement(Namespace = "")]
        public string AccDoc_DocNum { get; set; }

        [XmlElement(Namespace = "")]
        public DateTime AccDoc_DocDate { get; set; }

        [XmlElement(Namespace = "")]
        public DateTime? ExecDate { get; set; }

        [XmlElement(Namespace = "")]
        public decimal? BasicRequisites_PaySum { get; set; }

        [XmlElement(Namespace = "")]
        public string CurrCode_OKV { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_INN { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_KPP { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_Name { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_AccNum { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_BIK { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_CorrAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_BankName { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_CheckAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_INN { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_KPP { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_Name { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_AccNum { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_BIK { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_CorrAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_BankName { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_CheckAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string DepInfo_PayPurpose { get; set; }

        [XmlArray]
        public List<OrdersAcc_ITEM> OrdersAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string Payer_TOFKCode { get; set; }

        [XmlElement(Namespace = "")]
        public string Recip_TOFKCode { get; set; }
    }


    public class OrdersAcc_ITEM
    {
        [XmlElement(Namespace = "")]
        public string LineNum { get; set; }

        [XmlElement(Namespace = "")]
        public string Order_IGK { get; set; }

        [XmlElement(Namespace = "")]
        public string Order_Faip { get; set; }

        [XmlElement(Namespace = "")]
        public string Order_CodeObjectPay { get; set; }

        [XmlElement(Namespace = "")]
        public string Order_CodeObjectRec { get; set; }

        [XmlElement(Namespace = "")]
        public string Order_AnalyticCodePay { get; set; }

        [XmlElement(Namespace = "")]
        public string Order_AnalyticCodeRec { get; set; }

        [XmlElement(Namespace = "")]
        public decimal? Order_Sum { get; set; }
    }
}
