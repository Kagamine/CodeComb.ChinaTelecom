using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace CodeComb.ChinaTelecom.Puller
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(Deamon);
            t.Start();
        }

        static string api = "http://amamiyayuuko.imwork.net:22280/Api/";

        static void Deamon()
        {
            var http = new HttpHelper();
            while (true)
            {
                var lastId = http.HttpGet(api + "GetCustomerLastId");
                using (var conn = new OdbcConnection("Dsn=CCATSUPT;uid=qqhr01;dbq=CCATSUPT;dba=W;apa=T;exc=F;fen=T;qto=T;frc=10;fdl=10;lob=T;rst=T;btd=F;bnf=F;bam=IfAllSuccessful;num=NLS;dpm=F;mts=T;mdi=F;csr=F;fwc=F;fbs=64000;tlo=O;Pwd=qqhr2012"))
                {
                    conn.Open();
                    var cmd = new OdbcCommand("select * from SVR_QQHR_USERBILL where V_id > '" + lastId + "'", conn);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                var args = new List<Argument>
                            {
                                new Argument { Key = "Id", Value = reader["V_id"].ToString() },
                                new Argument { Key = "Area", Value = reader["V_area_code"].ToString() },
                                new Argument { Key = "Product", Value = reader["V_prd_code"].ToString() },
                                new Argument { Key = "Status", Value = reader["V_processinst_state"].ToString() },
                                new Argument { Key = "ComplainTime", Value = reader["V_complain_time"].ToString() },
                                new Argument { Key = "CreateTime", Value = reader["V_create_date"].ToString() },
                                new Argument { Key = "ReceiveTime", Value = reader["V_receive_time"].ToString() },
                                new Argument { Key = "BizCoverTime", Value = reader["V_biz_recover_time"].ToString() },
                                new Argument { Key = "FaultRecoverTime", Value = reader["V_fault_recover_time"].ToString() },
                                new Argument { Key = "PhoneNumber", Value = reader["V_call_no"].ToString() },
                                new Argument { Key = "CustomerName", Value = reader["V_cust_name"].ToString() },
                                new Argument { Key = "FaultDetail", Value = reader["V_fault_detail"].ToString() },
                                new Argument { Key = "Account", Value = reader["V_fault_no"].ToString() },
                                new Argument { Key = "FaultResource", Value = reader["V_fault_recsource"].ToString() },
                                new Argument { Key = "FaultCustomerLevel", Value = reader["V_cust_level"].ToString() },
                                new Argument { Key = "AccessTime", Value = reader["V_access_time"].ToString() },
                                new Argument { Key = "RepairUnit", Value = reader["V_repair_unit"].ToString() },
                                new Argument { Key = "RepairPost", Value = reader["V_repair_post"].ToString() },
                                new Argument { Key = "EndTime", Value = reader["V_end_time"].ToString() },
                                new Argument { Key = "Content", Value = reader["V_fault_content"].ToString() }
                            };
                                http.HttpPost(api + "InsertCustomer", args);
                                Console.WriteLine("用户层" + reader["V_id"].ToString() + "导入成功");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    lastId = http.HttpGet(api + "GetCustomerLastId");
                    cmd = new OdbcCommand("select * from SVR_QQHR_OPENBILL where V_id > '" + lastId + "'");
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                var args = new List<Argument>
                            {
                                new Argument { Key = "Id", Value = reader["V_id"].ToString() },
                                new Argument { Key = "Product", Value = reader["V_product"].ToString() },
                                new Argument { Key = "Status", Value = reader["V_order_state"].ToString() },
                                new Argument { Key = "AccepteTime", Value = reader["V_accept_date"].ToString() },
                                new Argument { Key = "Address", Value = reader["V_st_address"].ToString() },
                                new Argument { Key = "FinishTime", Value = reader["V_finish_date"].ToString() },
                                new Argument { Key = "AccessType", Value = reader["V_accesstype"].ToString() },
                                new Argument { Key = "RepairUnit", Value = reader["V_repair_unit"].ToString() },
                                new Argument { Key = "RepairPost", Value = reader["V_repair_post"].ToString() },
                                new Argument { Key = "Event", Value = reader["V_event"].ToString() },
                                new Argument { Key = "Event2", Value = reader["V_event_2"].ToString() },
                                new Argument { Key = "Time1", Value = reader["V_item_value40"].ToString() },
                                new Argument { Key = "Time2", Value = reader["V_item_value42"].ToString() },
                                new Argument { Key = "Account", Value = reader["V_acc_nbr"].ToString() }
                            };
                                http.HttpPost(api + "InsertProvider", args);
                                Console.WriteLine("接入层" + reader["V_id"].ToString() + "导入成功");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                    Thread.Sleep(1000 * 60 * 10);
                }
            }
        }
    }
}
