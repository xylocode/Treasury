using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XyloCode.Tools.Treasury
{
    internal class TreasuryProcessing
    {
        string path;
        public string ClientBankExchange { get; set; }
        public List<TSE_0401060_D07> Data = new List<TSE_0401060_D07>();
        public List<TSE_0531852_D12> F0531852 = new List<TSE_0531852_D12>();

        DateTime processingDate;

        public TreasuryProcessing(string path, DateTime processingDate)
        {
            this.path = path;
            this.processingDate = processingDate;
        }

        static string[] GetFiles(DirectoryInfo dir, string searchPattern)
        {
            return dir.GetFiles(searchPattern, SearchOption.TopDirectoryOnly)
                .Select(x => x.FullName)
                .ToArray();
        }

        public void Run()
        {
            var dir = new DirectoryInfo(path);
            var D07 = GetFiles(dir, "TSE_0401060_D07_*.XML");
            var D08 = GetFiles(dir, "TSE_0401060_D08_*.XML");
            var all = D07.Union(D08);

            var xmlSerializer = new XmlSerializer(typeof(TSE_0401060_D07));
            foreach (var file in all)
            {
                var xmlReader = XmlReader.Create(file);
                var item = (TSE_0401060_D07)xmlSerializer.Deserialize(xmlReader);
                xmlReader.Close();
                xmlReader.Dispose();
                Data.Add(item);
            }

            /*
            var D12 = GetFiles(path, "TSE_0531852_D12_*.XML");
            xmlSerializer = new XmlSerializer(typeof(TSE_0531852_D12));
            foreach (var file in D12)
            {
                var xmlReader = XmlReader.Create(file);
                var item = (TSE_0531852_D12)xmlSerializer.Deserialize(xmlReader);
                xmlReader.Close();
                xmlReader.Dispose();
                F0531852.Add(item);
            }
            */
        }

        public void Create1C()
        {
            var now = DateTime.Now;
            var start = Data.Select(x => x.BasicRequisites_DocDate).Min();
            var end = Data.Select(x => x.BasicRequisites_DocDate).Max();
            

            var sb = new StringBuilder();
            sb.AppendLine("1CClientBankExchange");
            sb.AppendLine("ВерсияФормата=1.03");
            sb.AppendLine("Кодировка=Windows");
            sb.AppendLine("Отправитель=Федеральное казначейство");
            sb.AppendLine("Получатель=");
            sb.AppendLine($"ДатаСоздания={now.ToShortDateString()}");
            sb.AppendLine($"ВремяСоздания={now.ToShortTimeString()}");
            sb.AppendLine($"ДатаНачала={start.ToShortDateString()}");
            sb.AppendLine($"ДатаКонца={start.ToShortDateString()}");
            sb.AppendLine($"РасчСчет={Properties.Settings.Default.BankAccountNumber}");
            sb.AppendLine();

            //sb.AppendLine("СекцияРасчСчет");
            //sb.AppendLine($"ДатаНачала={start.ToShortDateString()}");
            //sb.AppendLine($"ДатаКонца={start.ToShortDateString()}");
            //sb.AppendLine($"РасчСчет={Properties.Settings.Default.BankAccountNumber}");
            //sb.AppendLine("НачальныйОстаток=0.00");
            //sb.AppendLine("ВсегоПоступило=0.00");
            //sb.AppendLine("ВсегоСписано=0.00");
            //sb.AppendLine("КонечныйОстаток=0.00");
            //sb.AppendLine("КонецРасчСчет");
            //sb.AppendLine();

            foreach (var item in Data)
            {
                sb.AppendLine("СекцияДокумент=Платежное поручение");
                sb.AppendLine($"Номер={item.BasicRequisites_DocNum}");
                sb.AppendLine($"Дата={item.BasicRequisites_DocDate.ToShortDateString()}");
                //sb.AppendLine($"ДатаСписано=");
                sb.AppendLine($"ДатаПоступило={processingDate.ToShortDateString()}");
                sb.AppendLine($"Сумма={item.BasicRequisites_PaySum:F2}");

                sb.AppendLine($"Плательщик={item.PayerAndRecipient_Payer_Name}");
                sb.AppendLine($"ПлательщикИНН={item.PayerAndRecipient_Payer_INN}");
                sb.AppendLine($"ПлательщикКПП={item.PayerAndRecipient_Payer_KPP}");
                sb.AppendLine($"ПлательщикБИК={item.PayerAndRecipient_Payer_BIK}");
                sb.AppendLine($"ПлательщикБанк1={item.PayerAndRecipient_Payer_BankName}");
                sb.AppendLine($"ПлательщикКорсчет={item.PayerAndRecipient_Payer_CorrAcc}");
                sb.AppendLine($"ПлательщикСчет={item.PayerAndRecipient_Payer_CheckAcc}");
                
                sb.AppendLine($"Получатель={item.PayerAndRecipient_Recip_Name}");
                sb.AppendLine($"ПолучательИНН={item.PayerAndRecipient_Recip_INN}");
                sb.AppendLine($"ПолучательКПП={item.PayerAndRecipient_Recip_KPP}");
                sb.AppendLine($"ПолучательБИК={item.PayerAndRecipient_Recip_BIK}");
                sb.AppendLine($"ПолучательБанк1={item.PayerAndRecipient_Recip_BankName}");
                sb.AppendLine($"ПолучательКорсчет={item.PayerAndRecipient_Recip_CorrAcc}");
                sb.AppendLine($"ПолучательСчет={item.PayerAndRecipient_Recip_CheckAcc}");

                sb.AppendLine($"ВидПлатежа=электронно");
                sb.AppendLine($"ВидОплаты=01");
                //sb.AppendLine($"СрокАкцепта=");
                //sb.AppendLine($"УсловиеОплаты1=");
                sb.AppendLine($"СтатусСоставителя={item.TAX_DrawStat}");
                //sb.AppendLine($"ПоказательКБК=");
                //sb.AppendLine($"ОКАТО=0");
                //sb.AppendLine($"ПоказательОснования=0");
                //sb.AppendLine($"ПоказательПериода=0");
                //sb.AppendLine($"ПоказательНомера=0");
                //sb.AppendLine($"ПоказательДаты=0");
                //sb.AppendLine($"ПоказательТипа=0");
                sb.AppendLine($"Очередность={item.AdditionalInfo_PayOrder}");
                sb.AppendLine($"Код={item.TAX_UIN}");
                sb.AppendLine($"НазначениеПлатежа={item.TranscriptPP_PayPurpose}");
                //sb.AppendLine($"КодНазПлатежа="); //{item.SpecifDetail_D08?[0]?.CodeCS}
                //sb.AppendLine($"ВидАккредитива=");
                //sb.AppendLine($"СрокПлатежа=");
                //sb.AppendLine($"НомерСчетаПоставщика=");
                //sb.AppendLine($"ПлатежПоПредст=");
                //sb.AppendLine($"ДополнУсловия=");
                //sb.AppendLine($"ДатаОтсылкиДок=");
                sb.AppendLine("КонецДокумента");
                sb.AppendLine();
            }

            sb.AppendLine("КонецФайла");
            ClientBankExchange = sb.ToString();
        }
    }
}
