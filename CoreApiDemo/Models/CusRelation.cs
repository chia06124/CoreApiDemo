using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class CusRelation
    {
        public int CusRelationId { get; set; }
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public string RelationType { get; set; }
        public int RelationSerial { get; set; }
        public string RelationChName { get; set; }
        public string RelationEngName { get; set; }
        public string RelationIdno { get; set; }
        public string RelationShip { get; set; }
        public string RelationBirthday { get; set; }
        public string RelationNationality { get; set; }
        public string RegZip { get; set; }
        public string RegAddr { get; set; }
        public string RegTelArea { get; set; }
        public string RegTelNumber { get; set; }
        public string ComZip { get; set; }
        public string ComAddr { get; set; }
        public string ComTelArea { get; set; }
        public string ComTelNumber { get; set; }
        public string CompTelArea { get; set; }
        public string CompTelNumber { get; set; }
        public string CompTelExt { get; set; }
        public string Mphone { get; set; }
        public string ServiceClass { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
