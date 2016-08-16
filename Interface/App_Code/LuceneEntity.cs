using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class CdsBid
{
    public const string SegField = "Name,Description";
    public int ID { get; set; }
    public int AreaID { get; set; }
    public int CatalogID { get; set; }
    public int IndustryID { get; set; }
    public string Description { get; set; }
    public string Deadline { get; set; }
    public int Status { get; set; }
    public string Name { get; set; }
    public string ImagePath { get; set; }
    public DateTime CreateTime { get; set; }

    public CdsBid()
    { }

    public CdsBid(int _Id, int _areaId, int _catalogID, int _industryID, string _Description, string _Deadline, int _Status, string _Name, string _ImagePath, DateTime _CreateTime)
    {
        this.ID = _Id;
        this.AreaID = _areaId;
        this.CatalogID = _catalogID;
        this.IndustryID = _industryID;
        this.Description = _Description;
        this.Deadline = _Deadline;
        this.Status = _Status;
        this.Name = _Name;
        this.ImagePath = _ImagePath;
        this.CreateTime = _CreateTime;
    }
}