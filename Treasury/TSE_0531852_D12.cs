using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace XyloCode.Tools.Treasury
{
    [XmlRoot(Namespace = "http://www.roskazna.ru/eb/domain/TSE_0531852_D12/formular", IsNullable = true)]
    public class TSE_0531852_D12
    {
        [XmlElement(Namespace = "")]
        public Guid BasicRequisites_DocGuid { get; set; }

        [XmlElement(Namespace = "")]
        public string BasicRequisites_DocNum { get; set; }

        [XmlElement(Namespace = "")]
        public DateTime BasicRequisites_DocDate { get; set; }

        [XmlElement(Namespace = "")]
        public string BasicRequisites_NumberOrFK { get; set; }

        [XmlElement(Namespace = "")]
        public DateTime BasicRequisites_DateRequest { get; set; }

        [XmlElement(Namespace = "")]
        public string RequisitesClient_CodeClient { get; set; }

        [XmlElement(Namespace = "")]
        public string RequisitesClient_NameClient { get; set; }

        [XmlElement(Namespace = "")]
        public string RequisitesClient_AccountNumberClient { get; set; }

        [XmlElement(Namespace = "")]
        public string RequisitesClient_CodeOrFK { get; set; }

        [XmlElement(Namespace = "")]
        public string RequisitesClient_NameOrFK { get; set; }

        [XmlElement(Namespace = "")]
        public string Sign_PostBoss { get; set; }

        [XmlElement(Namespace = "")]
        public string Sign_FIOBoss { get; set; }

        [XmlElement(Namespace = "")]
        public string Sign_PostExecutor { get; set; }

        [XmlElement(Namespace = "")]
        public string Sign_FIOexecutor { get; set; }

        [XmlElement(Namespace = "")]
        public string Sign_PhoneExecutor { get; set; }

        [XmlElement(Namespace = "")]
        public DateTime Sign_DateSign { get; set; }

        [XmlElement(Namespace = "")]
        public string MarkFC_PostBoss { get; set; }

        [XmlElement(Namespace = "")]
        public string MarkFC_FioBossAuthorized { get; set; }

        [XmlElement(Namespace = "")]
        public string MarkFC_PostExecutor { get; set; }

        [XmlElement(Namespace = "")]
        public string MarkFC_FIOexecutor { get; set; }

        [XmlElement(Namespace = "")]
        public string MarkFC_PhoneExecutor { get; set; }

        [XmlArray(Namespace = "")]
        public List<TSE_ClarDetal_D12_ITEM> TSE_ClarDetal_D12 { get; set; }

        [XmlArray(Namespace = "")]
        public List<TSE_RefDetal_D12_ITEM> TSE_RefDetal_D12 { get; set; }


    }

    [Serializable]
    public class TSE_ClarDetal_D12_ITEM
    {
        [XmlElement(Namespace = "")]
        public int NumberRow { get; set; }

        [XmlElement(Namespace = "")]
        public string NameClarDoc { get; set; }

        [XmlElement(Namespace = "")]
        public Guid GuidClarDoc { get; set; }

        [XmlElement(Namespace = "")]
        public int NumClarDoc { get; set; }

        [XmlElement(Namespace = "")]
        public DateTime DateClarDoc { get; set; }

        [XmlElement(Namespace = "")]
        public decimal SUMMA { get; set; }

        [XmlElement(Namespace = "")]
        public string PurposePayment { get; set; }
    }

    [Serializable]
    public class TSE_RefDetal_D12_ITEM
    {
        [XmlElement(Namespace = "")]
        public int NumberRow { get; set; }

        [XmlElement(Namespace = "")]
        public string NameRecipient { get; set; }

        [XmlElement(Namespace = "")]
        public string InnRecipient { get; set; }

        [XmlElement(Namespace = "")]
        public string KppRecipient { get; set; }

        [XmlElement(Namespace = "")]
        public TypeOperationVerified TypeOperationVerified { get; set; }

        [XmlElement(Namespace = "")]
        public string CodeTargetSubsidy { get; set; }

        [XmlElement(Namespace = "")]
        public string KodRazdelL { get; set; }

        [XmlElement(Namespace = "")]
        public string SUMMA { get; set; }

        [XmlElement(Namespace = "")]
        public string IGK { get; set; }
    }

    [Serializable]
    public class TypeOperationVerified
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
