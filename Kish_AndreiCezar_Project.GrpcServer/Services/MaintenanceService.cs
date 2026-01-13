using Grpc.Core;
using Kish_AndreiCezar_Project.GrpcServer.Protos;

namespace Kish_AndreiCezar_Project.GrpcServer.Services;

public class MaintenanceService : MaintenanceAdvisor.MaintenanceAdvisorBase
{
    public override Task<MaintenanceReply> GetSchedule(MaintenanceRequest request, ServerCallContext context)
    {
        var vehicleType = request.CarModel?.Trim() ?? "Car";
        var mileage = request.MileageKm;
        var tasks = new List<string>();
        string severity;

        switch (vehicleType.ToLower())
        {
            case "car":
                tasks.Add("Inspectie vizuala generala");
                tasks.Add("Diagnoza sistem electronic");
                
                if (mileage > 200000)
                {
                    tasks.Add("Inlocuire distributie completa");
                    tasks.Add("Verificare compresie motor");
                    tasks.Add("Schimb ulei motor + filtre");
                    tasks.Add("Verificare suspensie si amortizoare");
                    tasks.Add("Inspectie sistem de franare complet");
                    severity = "Critica";
                }
                else if (mileage > 150000)
                {
                    tasks.Add("Inlocuire distributie");
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Verificare compresie motor");
                    tasks.Add("Curatare EGR");
                    tasks.Add("Schimb ulei + filtre");
                    severity = "Ridicata";
                }
                else if (mileage > 100000)
                {
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Curatare EGR");
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare suspensie");
                    severity = "Ridicata";
                }
                else if (mileage > 60000)
                {
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Rotire anvelope");
                    tasks.Add("Verificare sistem de franare");
                    severity = "Medie";
                }
                else
                {
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Rotire anvelope");
                    severity = "Redusa";
                }
                break;

            case "truck":
                tasks.Add("Inspectie vizuala generala");
                tasks.Add("Diagnoza sistem electronic");
                tasks.Add("Verificare sistem de franare");
                
                if (mileage > 500000)
                {
                    tasks.Add("Revizie completa motor");
                    tasks.Add("Inlocuire distributie");
                    tasks.Add("Verificare compresie motor");
                    tasks.Add("Schimb ulei motor + filtre");
                    tasks.Add("Verificare suspensie si amortizoare");
                    tasks.Add("Inspectie sistem de franare complet");
                    tasks.Add("Verificare transmisie");
                    severity = "Critica";
                }
                else if (mileage > 300000)
                {
                    tasks.Add("Inlocuire distributie");
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Verificare compresie motor");
                    tasks.Add("Curatare EGR");
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare suspensie");
                    severity = "Ridicata";
                }
                else if (mileage > 200000)
                {
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Curatare EGR");
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare suspensie");
                    tasks.Add("Verificare transmisie");
                    severity = "Ridicata";
                }
                else if (mileage > 100000)
                {
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare sistem de franare");
                    tasks.Add("Verificare suspensie");
                    severity = "Medie";
                }
                else
                {
                    tasks.Add("Schimb ulei + filtre");
                    severity = "Redusa";
                }
                break;

            case "bus":
                tasks.Add("Inspectie vizuala generala");
                tasks.Add("Diagnoza sistem electronic");
                tasks.Add("Verificare sistem de franare");
                tasks.Add("Verificare sistem de siguranta");
                
                if (mileage > 800000)
                {
                    tasks.Add("Revizie completa motor");
                    tasks.Add("Inlocuire distributie");
                    tasks.Add("Verificare compresie motor");
                    tasks.Add("Schimb ulei motor + filtre");
                    tasks.Add("Verificare suspensie si amortizoare");
                    tasks.Add("Inspectie sistem de franare complet");
                    tasks.Add("Verificare transmisie");
                    tasks.Add("Verificare sistem de climatizare");
                    severity = "Critica";
                }
                else if (mileage > 500000)
                {
                    tasks.Add("Inlocuire distributie");
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Verificare compresie motor");
                    tasks.Add("Curatare EGR");
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare suspensie");
                    tasks.Add("Verificare sistem de climatizare");
                    severity = "Ridicata";
                }
                else if (mileage > 300000)
                {
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Curatare EGR");
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare suspensie");
                    tasks.Add("Verificare transmisie");
                    severity = "Ridicata";
                }
                else if (mileage > 150000)
                {
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare sistem de franare");
                    tasks.Add("Verificare suspensie");
                    severity = "Medie";
                }
                else
                {
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare sistem de siguranta");
                    severity = "Redusa";
                }
                break;

            case "motorcycle":
                tasks.Add("Inspectie vizuala generala");
                tasks.Add("Diagnoza sistem electronic");
                
                if (mileage > 100000)
                {
                    tasks.Add("Inlocuire lant distributie");
                    tasks.Add("Verificare compresie motor");
                    tasks.Add("Schimb ulei motor + filtre");
                    tasks.Add("Verificare suspensie");
                    tasks.Add("Inspectie sistem de franare");
                    severity = "Critica";
                }
                else if (mileage > 60000)
                {
                    tasks.Add("Inlocuire lant distributie");
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare suspensie");
                    severity = "Ridicata";
                }
                else if (mileage > 30000)
                {
                    tasks.Add("Schimb lichid frana");
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare sistem de franare");
                    severity = "Medie";
                }
                else
                {
                    tasks.Add("Schimb ulei + filtre");
                    tasks.Add("Verificare sistem de franare");
                    severity = "Redusa";
                }
                break;

            default:
                tasks.Add("Inspectie vizuala");
                tasks.Add("Diagnoza rapida");
                if (mileage > 150000)
                {
                    tasks.Add("Schimb ulei + filtre");
                    severity = "Medie";
                }
                else
                {
                    tasks.Add("Schimb ulei + filtre");
                    severity = "Redusa";
                }
                break;
        }

        var reply = new MaintenanceReply
        {
            Recommendation = $"Plan de intretinere pentru {vehicleType} la {mileage:N0} km",
            Severity = severity
        };
        reply.SuggestedTasks.AddRange(tasks);

        return Task.FromResult(reply);
    }
}

