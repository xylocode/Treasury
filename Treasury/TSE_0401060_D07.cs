using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace XyloCode.Tools.Treasury
{
    [XmlRoot(Namespace = "http://www.roskazna.ru/eb/domain/TSE_0401060_D07/formular", IsNullable = true)]
    public class TSE_0401060_D07
    {
        [XmlAttribute]
        public string Version { get; set; }

        [XmlElement(Namespace = "")]
        public Guid BasicRequisites_DocGuid { get; set; }

        [XmlElement(Namespace = "")]
        public int BasicRequisites_DocNum { get; set; }

        [XmlElement(Namespace = "")]
        public DateTime BasicRequisites_DocDate { get; set; }

        [XmlElement(Namespace = "")]
        public decimal BasicRequisites_PaySum { get; set; }

        [XmlElement(Namespace = "")]
        public int AdditionalInfo_PayOrder { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_INN { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_KPP { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_PersonalAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_Name { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_CheckAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_BIK { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_BankName { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Payer_CorrAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Recip_INN { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Recip_KPP { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Recip_Name { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Recip_CheckAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Recip_BIK { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Recip_BankName { get; set; }

        [XmlElement(Namespace = "")]
        public string PayerAndRecipient_Recip_CorrAcc { get; set; }

        [XmlElement(Namespace = "")]
        public string TAX_UIN { get; set; }

        [XmlElement(Namespace = "")]
        public string TAX_DrawStat { get; set; }

        [XmlElement(Namespace = "")]
        public string TranscriptPP_PayPurpose { get; set; }

        [XmlArray(Namespace = "")]
        public List<SpecifDetail_D08_ITEM> SpecifDetail_D08 { get; set; }

    }


    public class SpecifDetail_D08_ITEM
    {
        [XmlElement(Namespace = "")]
        public string AnalyticCodePay { get; set; }

        [XmlElement(Namespace = "")]
        public string CodeCS { get; set; }

        [XmlElement(Namespace = "")]
        public TypeCodeObjPayer TypeCodeObjPayer { get; set; }

        [XmlElement(Namespace = "")]
        public decimal SUMMA { get; set; }
    }


    [Serializable]
    public class TypeCodeObjPayer
    {
        [XmlAttribute("code", Namespace = "")]
        public string Code { get; set; }

        [XmlAttribute("value", Namespace = "")]
        public string Value { get; set; }
    }
}
