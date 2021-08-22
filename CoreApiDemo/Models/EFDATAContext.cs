using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class EFDATAContext : DbContext
    {
        public EFDATAContext()
        {
        }

        public EFDATAContext(DbContextOptions<EFDATAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CusBaseDatum> CusBaseData { get; set; }
        public virtual DbSet<CusCreditDatum> CusCreditData { get; set; }
        public virtual DbSet<CusRelation> CusRelations { get; set; }
        public virtual DbSet<Futdatum> Futdata { get; set; }
        public virtual DbSet<Nrldatum> Nrldata { get; set; }
        public virtual DbSet<O010000M> O010000Ms { get; set; }
        public virtual DbSet<PhotoDatum> PhotoData { get; set; }
        public virtual DbSet<Sbkdatum> Sbkdata { get; set; }
        public virtual DbSet<Smsdatum> Smsdata { get; set; }
        public virtual DbSet<SysCodeMap> SysCodeMaps { get; set; }
        public virtual DbSet<TaCompany> TaCompanies { get; set; }
        public virtual DbSet<TaSale> TaSales { get; set; }
        public virtual DbSet<TaxResidency> TaxResidencies { get; set; }
        public virtual DbSet<TxnBank> TxnBanks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EFDATA;Trusted_Connection=True");
            //            }
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CusBaseDatum>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo })
                    .HasName("PK_OO_CusBaseData");

                entity.HasComment("場外開戶_客戶基本資料檔");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.BirthCity)
                    .HasMaxLength(50)
                    .HasComment("出生/註冊城市(對照sysCodeMap BirthCity)");

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(50)
                    .HasComment("出生/註冊國家(地區)(對照sysCodeMap BirthCountry) (當中華民國時城市為選單必填，其他國家為自行輸入)");

                entity.Property(e => e.Birthday)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("出生(設立)日期");

                entity.Property(e => e.ComAddr)
                    .HasMaxLength(50)
                    .HasComment("通訊地址");

                entity.Property(e => e.ComTelArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("通訊電話區碼");

                entity.Property(e => e.ComTelNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("通訊電話");

                entity.Property(e => e.ComZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("通訊地址:郵遞區號");

                entity.Property(e => e.CompTelArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("公司電話(區碼)");

                entity.Property(e => e.CompTelExt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("公司電話(分機)");

                entity.Property(e => e.CompTelNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("公司電話(市內號碼)");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .HasComment("服務機構");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("最後異動人");

                entity.Property(e => e.CustClass)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasComment("來源別 0 = 業代開發 1 = 公司分配 24 = 電商客戶");

                entity.Property(e => e.CustEngName)
                    .HasMaxLength(30)
                    .HasComment("英文名稱");

                entity.Property(e => e.CustIdno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CustIDNo")
                    .HasComment("身分證統一編號/證(期)交所核發證號");

                entity.Property(e => e.CustName)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasComment("客戶名稱");

                entity.Property(e => e.CustTaxId)
                    .HasMaxLength(50)
                    .HasColumnName("CustTaxID")
                    .HasComment("稅籍編號/居留證字號");

                entity.Property(e => e.DocWay)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("(N'以電子方式領取')")
                    .HasComment("開戶文件副本領取方式(以電子方式領取)");

                entity.Property(e => e.Edu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("教育程度\r\n代碼(對照sysCodeMap TA_Edu)");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMail")
                    .HasComment("電子郵件信箱");

                entity.Property(e => e.FaxArea)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')")
                    .HasComment("傳真電話(區碼)");

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment("傳真電話(市內號碼)");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasComment("性別");

                entity.Property(e => e.JobOcc)
                    .HasMaxLength(10)
                    .HasComment("職業代碼(對照sysCodeMap TA_Edu)(其他/無業/學生 可不填寫公司職稱公司電話 其餘要填寫)");

                entity.Property(e => e.JobOccDesc)
                    .HasMaxLength(20)
                    .HasComment("其他職業說明");

                entity.Property(e => e.Mphone)
                    .HasMaxLength(20)
                    .HasColumnName("MPhone")
                    .HasComment("行動電話");

                entity.Property(e => e.Nationality)
                    .HasMaxLength(50)
                    .HasComment("國籍/國名\r\n");

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .HasComment("擔任職務(職稱)");

                entity.Property(e => e.RegAddr)
                    .HasMaxLength(50)
                    .HasComment("戶籍/公司登記地址:地址");

                entity.Property(e => e.RegTelArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("戶籍電話\r\n(區碼)");

                entity.Property(e => e.RegTelNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("戶籍電話(市內號碼)");

                entity.Property(e => e.RegZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("戶籍/公司登記地址:郵遞區號");

                entity.Property(e => e.ResiAddr)
                    .HasMaxLength(500)
                    .HasComment("現行居住地址");
            });

            modelBuilder.Entity<CusCreditDatum>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo })
                    .HasName("PK_OO_CusCreditData");

                entity.HasComment("場外開戶_客戶徵信資料檔");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.Arrears)
                    .HasMaxLength(10)
                    .HasComment("有無借貸(有-借貸金額/無)");

                entity.Property(e => e.ArrearsVal)
                    .HasMaxLength(10)
                    .HasComment("借貸金額");

                entity.Property(e => e.AvgDeposit)
                    .HasMaxLength(10)
                    .HasComment("銀行月平均存款餘額");

                entity.Property(e => e.Bounced)
                    .HasMaxLength(10)
                    .HasComment("有無退票記錄(有/無)");

                entity.Property(e => e.ComCapital)
                    .HasMaxLength(10)
                    .HasComment("實收資本額(法人)");

                entity.Property(e => e.CompanyIncome)
                    .HasMaxLength(10)
                    .HasComment("法人年營收(選單)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("最後異動人");

                entity.Property(e => e.ExpectedQuota)
                    .HasMaxLength(10)
                    .HasComment("希望單日買賣最高額度(選單)");

                entity.Property(e => e.FamilyAnnualIncome)
                    .HasMaxLength(10)
                    .HasComment("家庭年總收入(選單)");

                entity.Property(e => e.FundSize)
                    .HasMaxLength(10)
                    .HasComment("基金規模(法人)");

                entity.Property(e => e.FundsSources)
                    .HasMaxLength(10)
                    .HasComment("主要資金來源(選單)");

                entity.Property(e => e.FundsSourcesDsc)
                    .HasMaxLength(200)
                    .HasComment("主要資金來源其他");

                entity.Property(e => e.Immovables)
                    .HasMaxLength(10)
                    .HasComment("有無不動產(有-不動產市場價值)");

                entity.Property(e => e.ImmovablesVal)
                    .HasMaxLength(10)
                    .HasComment("不動產市場價值");

                entity.Property(e => e.Oa)
                    .HasMaxLength(10)
                    .HasColumnName("OA")
                    .HasComment("開戶原因(選單)\r\n");

                entity.Property(e => e.Oareason)
                    .HasMaxLength(200)
                    .HasColumnName("OAReason")
                    .HasComment("開戶原因(其他說明)");

                entity.Property(e => e.OtherAssets)
                    .HasMaxLength(10)
                    .HasComment("有無其他資產(有-其他資產項目、其他資產金額/無)");

                entity.Property(e => e.OtherAssetsName)
                    .HasMaxLength(200)
                    .HasComment("其他資產項目");

                entity.Property(e => e.OtherAssetsVal)
                    .HasMaxLength(10)
                    .HasComment("其他資產金額");

                entity.Property(e => e.OtherBrokersAcc)
                    .HasMaxLength(10)
                    .HasComment("有無在其他證券商開戶(有/無)");

                entity.Property(e => e.PersonalIncome)
                    .HasMaxLength(10)
                    .HasComment("個人/法人負責人年收入(選單)");

                entity.Property(e => e.TotalVal)
                    .HasMaxLength(10)
                    .HasComment("資產總值(選單)");

                entity.Property(e => e.TradingExp)
                    .HasMaxLength(10)
                    .HasComment("有無交易經驗");

                entity.Property(e => e.TradingExpBy)
                    .HasMaxLength(10)
                    .HasColumnName("TradingExpBY")
                    .HasComment("債券交易經驗(年)");

                entity.Property(e => e.TradingExpFy)
                    .HasMaxLength(10)
                    .HasColumnName("TradingExpFY")
                    .HasComment("期貨交易經驗(年)");

                entity.Property(e => e.TradingExpHy)
                    .HasMaxLength(10)
                    .HasColumnName("TradingExpHY")
                    .HasComment("房地產交易經驗(年)");

                entity.Property(e => e.TradingExpOtherN)
                    .HasMaxLength(200)
                    .HasComment("其他交易經驗類型");

                entity.Property(e => e.TradingExpOtherY)
                    .HasMaxLength(10)
                    .HasComment("其他交易經驗年資");

                entity.Property(e => e.TradingExpSy)
                    .HasMaxLength(10)
                    .HasColumnName("TradingExpSY")
                    .HasComment("股票交易經驗(年)");

                entity.Property(e => e.TradingFreq)
                    .HasMaxLength(10)
                    .HasComment("交易頻率(選單)");

                entity.Property(e => e.TradingTerm)
                    .HasMaxLength(10)
                    .HasComment("交易期限(選單)");
            });

            modelBuilder.Entity<CusRelation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CusRelation");

                entity.HasComment("場外開戶_關係人資料檔");

                entity.Property(e => e.ComAddr)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')")
                    .HasComment("通訊地址");

                entity.Property(e => e.ComTelArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("通訊電話區碼");

                entity.Property(e => e.ComTelNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("通訊電話");

                entity.Property(e => e.ComZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("通訊地址:郵遞區號");

                entity.Property(e => e.CompTelArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司電話(區碼)");

                entity.Property(e => e.CompTelExt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司電話(分機)");

                entity.Property(e => e.CompTelNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司電話(市內號碼)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("最後異動人");

                entity.Property(e => e.CusRelationId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CusRelationID");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.Mphone)
                    .HasMaxLength(20)
                    .HasColumnName("MPhone")
                    .HasDefaultValueSql("('')")
                    .HasComment("行動電話");

                entity.Property(e => e.RegAddr)
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')")
                    .HasComment("戶籍地址:地址");

                entity.Property(e => e.RegTelArea)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("戶籍電話:區碼");

                entity.Property(e => e.RegTelNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("戶籍電話");

                entity.Property(e => e.RegZip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("戶籍地址:郵遞區號");

                entity.Property(e => e.RelationBirthday)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')")
                    .HasComment("出生日期");

                entity.Property(e => e.RelationChName)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("('')")
                    .HasComment("中文名稱");

                entity.Property(e => e.RelationEngName)
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('')")
                    .HasComment("英文名稱");

                entity.Property(e => e.RelationIdno)
                    .HasMaxLength(50)
                    .HasColumnName("RelationIDNo")
                    .HasDefaultValueSql("('')")
                    .HasComment("身分證統一編號");

                entity.Property(e => e.RelationNationality)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment("國籍/國名");

                entity.Property(e => e.RelationSerial).HasComment("關係人序號");

                entity.Property(e => e.RelationShip)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')")
                    .HasComment("關係說明 緊急聯絡人: '父母子女' '兄弟姊妹''配偶''朋友''同事'其他說明 連帶保證人 父母 配偶 成年子女");

                entity.Property(e => e.RelationType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("關係人別  sysCodeMap CusRelation");

                entity.Property(e => e.ServiceClass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("業務別");
            });

            modelBuilder.Entity<Futdatum>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo })
                    .HasName("PK_OO_FUTData");

                entity.ToTable("FUTData");

                entity.HasComment("場外開戶_期貨資料檔");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.EtradingFlag)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("ETradingFlag")
                    .HasComment("電子交易 1同意申請/2暫不申請 加開時同證券");

                entity.Property(e => e.HonStockFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("提供留存於宏遠庫存  1 沒勾選 2 有勾選");

                entity.Property(e => e.HonTradingFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("提供留存於宏遠交易記錄  1 沒勾選 2 有勾選");

                entity.Property(e => e.MarginCallTrading)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasComment("追繳保證金方式_盤中:1:行動電話(簡訊), 2:電子郵件");

                entity.Property(e => e.MarginEway)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MarginEWay")
                    .HasComment("使用電話語音或網際網路系統提領保證金 1:同意申請 2: 不同意申請");

                entity.Property(e => e.MarketPrice)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("市價委託同意旗標 1:同意申請 2: 不同意申請");

                entity.Property(e => e.SettlementWay)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("對帳單/買賣報告書及通知函件領取方式 1郵寄/2親取/3Email");

                entity.Property(e => e.SignDocVer)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("契約內容版本相對路徑");
            });

            modelBuilder.Entity<Nrldatum>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo })
                    .HasName("PK_OO_NRLData");

                entity.ToTable("NRLData");

                entity.HasComment("場外開戶_不限貸資料檔");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.SignDocVer)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("契約內容版本相對路徑");
            });

            modelBuilder.Entity<O010000M>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo })
                    .HasName("PK_OO010000_M");

                entity.ToTable("O010000_M");

                entity.HasComment("場外開戶_案件資料");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("案件流水號");

                entity.Property(e => e.Com)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasComment("開戶公司代碼");

                entity.Property(e => e.ComName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("開戶分公司名");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.CustIdno)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CustIDNo")
                    .HasComment("客戶統編");

                entity.Property(e => e.CustType)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasComment("開戶身分類別代碼");

                entity.Property(e => e.DealAddr)
                    .IsRequired()
                    .HasMaxLength(400)
                    .HasComment("見簽地點");

                entity.Property(e => e.DealDate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("見簽日期");

                entity.Property(e => e.DealUserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("見簽人員代碼");

                entity.Property(e => e.OpenSales)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("開戶營業員代碼");

                entity.Property(e => e.OpenSalesName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasComment("開戶營業員名稱");
            });

            modelBuilder.Entity<PhotoDatum>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PK_OO_PhotoData");

                entity.HasComment("場外開戶_影像資料檔");

                entity.Property(e => e.Serial).HasComment("資料序號");

                entity.Property(e => e.Binary)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasComment("影像檔案[base64string]");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.Ptype)
                    .HasColumnName("PType")
                    .HasComment("影像主類別 1證件 2財力 3交割銀行 99其他");

                entity.Property(e => e.RoleCode).HasComment("角色別 1申請人 2未成年法代 3法人代表人 4華僑外國人 51證券受任人 52期貨受任人 53複委託受任人 54不限貸受任人");

                entity.Property(e => e.RoleCodeSerial).HasComment("角色別序編");

                entity.Property(e => e.Stype)
                    .HasColumnName("SType")
                    .HasComment("影像次類別 1身分證正 2身分證反 3第二證正 4第二證反 10證券台幣交割 20期貨出入金台幣 22期貨入金台幣2 23期貨入金台幣3 30期貨出入金外幣 32期貨入金外幣2 33期貨入金外幣3 40複委託交割外幣委託交割自有外幣 99其他");
            });

            modelBuilder.Entity<Sbkdatum>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo })
                    .HasName("PK_OO_SBKData");

                entity.ToTable("SBKData");

                entity.HasComment("場外開戶_複委託資料檔");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.SignDocVer)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("契約內容版本相對路徑");
            });

            modelBuilder.Entity<Smsdatum>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo })
                    .HasName("PK_OO_SMSData");

                entity.ToTable("SMSData");

                entity.HasComment("場外開戶_證券資料檔");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.EtradingFlag)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("ETradingFlag")
                    .HasComment("同意申請/暫不申請");

                entity.Property(e => e.SettlementWay)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasComment("對帳單/買賣報告書及通知函件領取方式 郵寄/親取/Email");

                entity.Property(e => e.SignDocVer)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasComment("契約內容版本相對路徑");

                entity.Property(e => e.TdccbookFlag)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("TDCCBookFlag")
                    .HasComment("手機存摺/紙本存摺");
            });

            modelBuilder.Entity<SysCodeMap>(entity =>
            {
                entity.HasKey(e => new { e.ClassCode, e.ItemName, e.Sdate })
                    .HasName("PK_sysCodeMap_1");

                entity.ToTable("sysCodeMap");

                entity.Property(e => e.ClassCode)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Class_Code")
                    .HasDefaultValueSql("('')")
                    .HasComment("欄位代碼");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(60)
                    .HasColumnName("Item_Name")
                    .HasDefaultValueSql("('')")
                    .HasComment("項目名稱");

                entity.Property(e => e.Sdate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDate")
                    .HasDefaultValueSql("('')")
                    .HasComment("開始日期");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Class_Name")
                    .HasDefaultValueSql("('')")
                    .HasComment("欄位名稱");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.Edate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EDate")
                    .HasDefaultValueSql("('')")
                    .HasComment("結束日期");

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Item_Code")
                    .HasDefaultValueSql("('')")
                    .HasComment("項目代碼");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("備註");

                entity.Property(e => e.Seq).HasComment("排序");
            });

            modelBuilder.Entity<TaCompany>(entity =>
            {
                entity.HasKey(e => e.Com);

                entity.ToTable("TA_Company");

                entity.Property(e => e.Com)
                    .ValueGeneratedNever()
                    .HasComment("公司代號");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司地址");

                entity.Property(e => e.ComName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司名稱");

                entity.Property(e => e.Cosy)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("券商代碼");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔日");

                entity.Property(e => e.Fax)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司傳真");

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("公司電話");

                entity.Property(e => e.Status)
                    .HasDefaultValueSql("((-1))")
                    .HasComment("狀態(0:營業中;1:歇業)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaSale>(entity =>
            {
                entity.HasKey(e => new { e.Com, e.Dept, e.Sales, e.EmpNo, e.Status });

                entity.ToTable("TA_Sales");

                entity.Property(e => e.Com).HasComment("公司代號,參照TA_Company");

                entity.Property(e => e.Dept).HasComment("部門代碼");

                entity.Property(e => e.Sales).HasComment("營業員代號");

                entity.Property(e => e.EmpNo).HasComment("員工編號");

                entity.Property(e => e.Status).HasComment("狀態(0:正常;1:註銷)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔日");

                entity.Property(e => e.Memo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("('')")
                    .HasComment("備註");

                entity.Property(e => e.MobileNo1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("行動電話1");

                entity.Property(e => e.MobileNo2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("行動電話2");

                entity.Property(e => e.PhoneExt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("營業員分機(多分機用空白間隔)");

                entity.Property(e => e.SalesName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('')")
                    .HasComment("姓名");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasDefaultValueSql("('')")
                    .HasComment("職稱");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TaxResidency>(entity =>
            {
                entity.HasKey(e => e.Serial)
                    .HasName("PK_OO_TaxResidency");

                entity.ToTable("TaxResidency");

                entity.HasComment("場外開戶_CRS稅務居民資料檔");

                entity.Property(e => e.Serial).HasComment("資料序號");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.FormId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.NationCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("國家代碼");

                entity.Property(e => e.NationName)
                    .HasMaxLength(50)
                    .HasComment("國家名稱");

                entity.Property(e => e.ReasonDesc)
                    .HasMaxLength(50)
                    .HasComment("無法提供稅籍編號原因其他說明");

                entity.Property(e => e.ReasonId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ReasonID")
                    .HasComment("無法提供稅籍編號原因代碼");

                entity.Property(e => e.TaxId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TaxID")
                    .HasComment("稅籍編號");
            });

            modelBuilder.Entity<TxnBank>(entity =>
            {
                entity.HasKey(e => new { e.FormId, e.FormNo, e.Type, e.Currency, e.DepositWithdraw })
                    .HasName("PK_OO_TxnBank");

                entity.ToTable("TxnBank");

                entity.HasComment("場外開戶_交割銀行");

                entity.Property(e => e.FormId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FormID")
                    .HasComment("案件代碼");

                entity.Property(e => e.FormNo)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasComment("案件流水號");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasComment("案件型態 1:證券 2:期貨 3:複委託\r\n");

                entity.Property(e => e.Currency)
                    .HasMaxLength(10)
                    .HasComment("交割幣別1:台幣 2:外幣 3.自有資金");

                entity.Property(e => e.DepositWithdraw).HasComment("1:出金 2:入金一 3.入金二 4.入金三");

                entity.Property(e => e.Account)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("('')")
                    .HasComment("帳號");

                entity.Property(e => e.BankBranchCode)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("('')")
                    .HasComment("金資代碼");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("建檔時間");

                entity.Property(e => e.CreateUser)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')")
                    .HasComment("建檔人員");

                entity.Property(e => e.Serial)
                    .ValueGeneratedOnAdd()
                    .HasComment("資料序號");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
