using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using T4_PR1_App.Models.Missatges;

public class IndicadorEnergetic
{
    [Required(ErrorMessage = MissatgesIndicador.RequiredData)]
    public DateTime Data { get; set; }
    public double PBEE_Hidroelectr { get; set; }
    public double PBEE_Carbo { get; set; }
    public double PBEE_GasNat { get; set; }
    [Name("PBEE_Fuel-Oil")]
    public double PBEE_Fuel_Oil { get; set; }
    public double PBEE_CiclComb { get; set; }
    public double PBEE_Nuclear { get; set; }
    public double CDEEBC_ProdBruta { get; set; }
    public double CDEEBC_ConsumAux { get; set; }
    [Required(ErrorMessage = MissatgesIndicador.RequiredCDEEBC_ProdNeta)]
    public double CDEEBC_ProdNeta { get; set; }
    public double CDEEBC_ConsumBomb { get; set; }
    [Required(ErrorMessage = MissatgesIndicador.RequiredCDEEBC_ProdDisp)]
    public double CDEEBC_ProdDisp { get; set; }
    public double CDEEBC_TotVendesXarxaCentral { get; set; }
    public double CDEEBC_SaldoIntercanviElectr { get; set; }
    [Required(ErrorMessage = MissatgesIndicador.RequiredCDEEBC_DemandaElectr)]
    public double CDEEBC_DemandaElectr { get; set; }
    public string? CDEEBC_TotalEBCMercatRegulat { get; set; }
    public string? CDEEBC_TotalEBCMercatLliure { get; set; }

    //Els [Default()] posen valors per defecte als camps que no tenen valor (nulls) al parsear el CSV
    [Default(0)]
    public double? FEE_Industria { get; set; }
    [Default(0)]
    public double? FEE_Terciari { get; set; }
    [Default(0)]
    public double? FEE_Domestic { get; set; }
    [Default(0)]
    public double? FEE_Primari { get; set; }
    [Default(0)]
    public double? FEE_Energetic { get; set; }
    [Default(0)]
    public double? FEEI_ConsObrPub { get; set; }
    [Default(0)]
    public double? FEEI_SiderFoneria { get; set; }
    [Default(0)]
    public double? FEEI_Metalurgia { get; set; }
    [Default(0)]
    public double? FEEI_IndusVidre { get; set; }
    [Default(0)]
    public double? FEEI_CimentsCalGuix { get; set; }
    [Default(0)]
    public double? FEEI_AltresMatConstr { get; set; }
    [Default(0)]
    public double? FEEI_QuimPetroquim { get; set; }
    [Default(0)]
    public double? FEEI_ConstrMedTrans { get; set; }
    [Default(0)]
    public double? FEEI_RestaTransforMetal { get; set; }
    [Default(0)]
    public double? FEEI_AlimBegudaTabac { get; set; }
    [Default(0)]
    public double? FEEI_TextilConfecCuirCalçat { get; set; }
    [Default(0)]
    public double? FEEI_PastaPaperCartro { get; set; }
    [Default(0)]
    public double? FEEI_AltresIndus { get; set; }
    public double DGGN_PuntFrontEnagas { get; set; }
    public double DGGN_DistrAlimGNL { get; set; }
    public double DGGN_ConsumGNCentrTerm { get; set; }
    [Required(ErrorMessage = MissatgesIndicador.RequiredCCAC_GasolinaAuto)]
    public double CCAC_GasolinaAuto { get; set; }
    public double CCAC_GasoilA { get; set; }
}
