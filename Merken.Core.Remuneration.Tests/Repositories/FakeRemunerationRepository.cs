using Merken.Core.Remuneration.Common;
using Merken.Core.Remuneration.Enum;
using Merken.Core.Remuneration.Interfaces;
using Merken.Core.Remuneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merken.Core.Remuneration.Tests.Repositories
{
    public class FakeRemunerationRepositoryBlueCollar : IRemunerationRepository
    {
        public List<IRemunArea> GetRemunerationAreas(IEmployerInformation employerInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunArea>
            {
                new RemunArea
                {
                    Order = 50,
                    Description = "WAGES",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Basisloon berekening arbeider",
                            ComponentType = "Merken.Core.Remuneration.Components.Wage.BlueCollarWageComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 100,
                    Description = "BRUTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "RSZ -13.07%",
                            ComponentType = "Merken.Core.Remuneration.Components.Bruto.SocialSecurityComponent"
                        },
                        new RemunComponent
                        {
                            Order = 300,
                            Description = "Social work bonus",
                            ComponentType = "Merken.Core.Remuneration.Components.Bruto.SocialWorkBonusComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 200,
                    Description = "TAXABLE",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Bedrijfsvoorheffing",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.WithholdingTaxOnProfessionalIncomeMonthlyComponent"
                        },
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "RSZ -13.7%",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.ChildrenOnChargeComponent"
                        },
                        new RemunComponent
                        {
                            Order = 300,
                            Description = "Vermindering BV voor lage lonen",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.DeductionForSmallWagesComponent"
                        },
                        new RemunComponent
                        {
                            Order = 400,
                            Description = "Fiscale werkbonus",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.FiscalWorkBonusComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 300,
                    Description = "NETTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "BBSZ",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.SpecialContributionForSocialSecurityComponent"
                        }
                    }
                }
            };
        }

        public List<IRemunComponent> GetRemunerationComponents(IEmployeeInformation employeeInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunComponent>
            {
                //BRUTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "RSZ -13.7%",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Percentage,
                    Amount = 0.1307d,
                    PreCalculations =  new List<IRemunComponent>{
                        new RemunComponent
                        {
                            Order = 0,
                            Description = "Bruto berekening arbeider 108%",
                            RemunType =  RemunType.Bruto,
                            OperatorType  = RemunOperatorType.Add,
                            CalculationType = RemunCalculationType.Percentage,
                            Amount = 0.08d
                        },
                    }
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Sociale Werkbonus",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 66.86d
                },

                //TAXABLE
                new RemunComponent
                {
                    Order = 1,
                    Description = "Bedrijfsvoorheffing",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 419.34d
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Kinderen ten laste",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 92.00d
                },
                new RemunComponent
                {
                    Order = 3,
                    Description = "BV vanaf 6.46",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 6.46d
                },
                new RemunComponent
                {
                    Order = 4,
                    Description = "Fiscale werkbonus",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 9.63d
                },

                //NETTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "BBSZ",
                    RemunType =  RemunType.Netto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 19.31d
                }
            };
        }
    }

    public class FakeRemunerationRepositoryWhiteCollar : IRemunerationRepository
    {
        public List<IRemunArea> GetRemunerationAreas(IEmployerInformation employerInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunArea>
            {
                new RemunArea
                {
                    Order = 0,
                    Description = "WAGES",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Basisloon berekening bediende 100%",
                            ComponentType = "Merken.Core.Remuneration.Components.Wage.WhiteCollarWageComponent"
                        },
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "Bruto dagvergoeding",
                            ComponentType = "Merken.Core.Remuneration.Components.Wage.DayCompensationComponent"
                        },
                        new RemunComponent
                        {
                            Order = 300,
                            Description = "Bruto waarde GSM voordeel",
                            ComponentType = "Merken.Core.Remuneration.Components.Wage.MobilePhoneCompensationComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 100,
                    Description = "BRUTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "RSZ -13.07%",
                            ComponentType = "Merken.Core.Remuneration.Components.Bruto.SocialSecurityComponent"
                        },
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "Voordeel natura wagen",
                            ComponentType = "Merken.Core.Remuneration.Components.Bruto.CompensationNaturaCompanyCarComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 200,
                    Description = "TAXABLE",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Bedrijfsvoorheffing",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.WithholdingTaxOnProfessionalIncomeMonthlyComponent"
                        },
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "Kosten eigen aan de werkgever",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.CostsForTheEmployerComponent"
                        },
                        new RemunComponent
                        {
                            Order = 300,
                            Description = "Aftrek voordeel natura wagen",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.DeductionCompanyCarComponent"
                        },
                        new RemunComponent
                        {
                            Order = 400,
                            Description = "Aftrek voordeel natura GSM",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.DeductionMobilePhoneComponent"
                        },
                        new RemunComponent
                        {
                            Order = 500,
                            Description = "Onbelast voordeel natura wagen",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.NonTaxableCompanyCarCompensationComponent"
                        },
                        new RemunComponent
                        {
                            Order = 600,
                            Description = "Afhouding Maaltijdcheques",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.MealVoucherComponent"
                        },
                        new RemunComponent
                        {
                            Order = 700,
                            Description = "Forfaitaire verblijfsvergoeding",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.CompensationForBusinessTravelComponent"
                        },
                        new RemunComponent
                        {
                            Order = 800,
                            Description = "BBSZ",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.SpecialContributionForSocialSecurityComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 300,
                    Description = "NETTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Advances",
                            ComponentType = "Merken.Core.Remuneration.Components.Netto.AdvancesComponent"
                        }
                    }
                }
            };
        }

        public List<IRemunComponent> GetRemunerationComponents(IEmployeeInformation employeeInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunComponent>
            {
                //BRUTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "RSZ -13.7%",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Percentage,
                    Amount = 0.1307d,
                    PreCalculations =  new List<IRemunComponent>{
                        new RemunComponent
                        {
                            Order = 0,
                            Description = "Bruto berekening arbeider 108%",
                            RemunType =  RemunType.Bruto,
                            OperatorType  = RemunOperatorType.Add,
                            CalculationType = RemunCalculationType.Percentage,
                            Amount = 0.08d
                        },
                    }
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Sociale Werkbonus",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 66.86d
                },

                //TAXABLE
                new RemunComponent
                {
                    Order = 1,
                    Description = "Bedrijfsvoorheffing",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 419.34d
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Kinderen ten laste",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 92.00d
                },
                new RemunComponent
                {
                    Order = 3,
                    Description = "BV vanaf 6.46",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 6.46d
                },
                new RemunComponent
                {
                    Order = 4,
                    Description = "Fiscale werkbonus",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 9.63d
                },

                //NETTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "BBSZ",
                    RemunType =  RemunType.Netto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 19.31d
                }
            };
        }
    }

    public class FakeRemunerationRepositoryWhiteCollarBasic : IRemunerationRepository
    {
        public List<IRemunArea> GetRemunerationAreas(IEmployerInformation employerInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunArea>
            {
                new RemunArea
                {
                    Order = 0,
                    Description = "WAGES",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Basisloon berekening bediende 100%",
                            ComponentType = "Merken.Core.Remuneration.Components.Wage.WhiteCollarWageComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 100,
                    Description = "BRUTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "RSZ -13.07%",
                            ComponentType = "Merken.Core.Remuneration.Components.Bruto.SocialSecurityComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 200,
                    Description = "TAXABLE",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Bedrijfsvoorheffing - Maandelijks",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.WithholdingTaxOnProfessionalIncomeMonthlyComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 300,
                    Description = "NETTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                    }
                }
            };
        }

        public List<IRemunComponent> GetRemunerationComponents(IEmployeeInformation employeeInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunComponent>
            {
                //BRUTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "RSZ -13.7%",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Percentage,
                    Amount = 0.1307d,
                    PreCalculations =  new List<IRemunComponent>{
                        new RemunComponent
                        {
                            Order = 0,
                            Description = "Bruto berekening arbeider 108%",
                            RemunType =  RemunType.Bruto,
                            OperatorType  = RemunOperatorType.Add,
                            CalculationType = RemunCalculationType.Percentage,
                            Amount = 0.08d
                        },
                    }
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Sociale Werkbonus",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 66.86d
                },

                //TAXABLE
                new RemunComponent
                {
                    Order = 1,
                    Description = "Bedrijfsvoorheffing",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 419.34d
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Kinderen ten laste",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 92.00d
                },
                new RemunComponent
                {
                    Order = 3,
                    Description = "BV vanaf 6.46",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 6.46d
                },
                new RemunComponent
                {
                    Order = 4,
                    Description = "Fiscale werkbonus",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 9.63d
                },

                //NETTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "BBSZ",
                    RemunType =  RemunType.Netto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 19.31d
                }
            };
        }
    }

    public class FakeRemunerationRepositoryWhiteCollarBasic2 : IRemunerationRepository
    {
        public List<IRemunArea> GetRemunerationAreas(IEmployerInformation employerInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunArea>
            {
                new RemunArea
                {
                    Order = 0,
                    Description = "WAGES",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Basisloon berekening bediende 100%",
                            ComponentType = "Merken.Core.Remuneration.Components.Wage.WhiteCollarWageComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 100,
                    Description = "BRUTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "RSZ -13.07%",
                            ComponentType = "Merken.Core.Remuneration.Components.Bruto.SocialSecurityComponent"
                        },
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "VAA bedrijfswagen",
                            ComponentType = "Merken.Core.Remuneration.Components.Bruto.CompensationNaturaCompanyCarComponent"
                        }
                    },
                },
                new RemunArea
                {
                    Order = 200,
                    Description = "TAXABLE",
                    RemunComponents = new List<IRemunComponent>
                    {
                        new RemunComponent
                        {
                            Order = 100,
                            Description = "Bedrijfsvoorheffing - Maandelijks",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.WithholdingTaxOnProfessionalIncomeMonthlyComponent"
                        },
                        new RemunComponent
                        {
                            Order = 200,
                            Description = "GSM Vergoeding",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.CompensationForMobilePhoneComponent"
                        },
                        new RemunComponent
                        {
                            Order = 300,
                            Description = "Kosten eigen aan de werkgever",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.CostsForTheEmployerComponent"
                        },
                        new RemunComponent
                        {
                            Order = 400,
                            Description = "Bijdrage sociale zekerheid",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.SpecialContributionForSocialSecurityComponent"
                        },
                        new RemunComponent
                        {
                            Order = 500,
                            Description = "VAA bedrijfswagen",
                            ComponentType = "Merken.Core.Remuneration.Components.Taxable.DeductionCompanyCarComponent"
                        }
                    }
                },
                new RemunArea
                {
                    Order = 300,
                    Description = "NETTO",
                    RemunComponents = new List<IRemunComponent>
                    {
                    }
                }
            };
        }

        public List<IRemunComponent> GetRemunerationComponents(IEmployeeInformation employeeInformation, DateTime? date = default(DateTime?))
        {
            return new List<IRemunComponent>
            {
                //BRUTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "RSZ -13.7%",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Percentage,
                    Amount = 0.1307d,
                    PreCalculations =  new List<IRemunComponent>{
                        new RemunComponent
                        {
                            Order = 0,
                            Description = "Bruto berekening arbeider 108%",
                            RemunType =  RemunType.Bruto,
                            OperatorType  = RemunOperatorType.Add,
                            CalculationType = RemunCalculationType.Percentage,
                            Amount = 0.08d
                        },
                    }
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Sociale Werkbonus",
                    RemunType =  RemunType.Bruto,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 66.86d
                },

                //TAXABLE
                new RemunComponent
                {
                    Order = 1,
                    Description = "Bedrijfsvoorheffing",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 419.34d
                },
                new RemunComponent
                {
                    Order = 2,
                    Description = "Kinderen ten laste",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 92.00d
                },
                new RemunComponent
                {
                    Order = 3,
                    Description = "BV vanaf 6.46",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 6.46d
                },
                new RemunComponent
                {
                    Order = 4,
                    Description = "Fiscale werkbonus",
                    RemunType =  RemunType.Taxable,
                    OperatorType  = RemunOperatorType.Add,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 9.63d
                },

                //NETTO
                new RemunComponent
                {
                    Order = 1,
                    Description = "BBSZ",
                    RemunType =  RemunType.Netto,
                    OperatorType  = RemunOperatorType.Subtract,
                    CalculationType = RemunCalculationType.Fixed,
                    Amount = 19.31d
                }
            };
        }
    }
}
