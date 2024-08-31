using Integration.DanceCore;
using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Tanssikisa.Blazor.Adapters;
using Tanssikisa.Blazor.Services;

namespace Tanssikisa.Blazor.Components.Pages
{
    public partial class Tuo
    {
        [Inject]
        required public ILogger<Tuo> Logger { get; init; }

        [Inject]
        required public ITapahtumaService TapahtumaService { get; init; }

        // Parikortiston tiedostojen tuonti

        private FluentInputFile? parikortistoBuffer = default;
        private int parikortistoProgressPercent = 0;
        private string parikortistoProgressTitle = string.Empty;
        private bool parikortistoIsCanceled = false;
        private readonly Dictionary<int, string> ParikortistoFiles = [];

        async Task OnParikortistoProgressChangeAsync(FluentInputFileEventArgs file)
        {
            parikortistoProgressPercent = file.ProgressPercent;
            parikortistoProgressTitle = file.ProgressTitle;

            // To cancel?
            file.IsCancelled = parikortistoIsCanceled;

            // New file
            if (!ParikortistoFiles.ContainsKey(file.Index))
            {
                var localFile = Path.GetTempFileName() + file.Name;
                ParikortistoFiles.Add(file.Index, localFile);
            }

            // Write to the FileStream
            await file.Buffer.AppendToFileAsync(ParikortistoFiles[file.Index]);
        }

        void OnParikortistoCompleted(IEnumerable<FluentInputFileEventArgs> files)
        {
            parikortistoProgressPercent = parikortistoBuffer!.ProgressPercent;
            parikortistoProgressTitle = parikortistoBuffer!.ProgressTitle;

            // For the demo, delete these files.
            foreach (var file in ParikortistoFiles)
            {
                File.Delete(file.Value);
            }
        }

        // Ilmoittautumisten tiedostojen tuonti
        private FluentInputFile? ilmoittautumisetBuffer = default;
        private int ilmoittautumisetProgressPercent = 0;
        private string ilmoittautumisetProgressTitle = string.Empty;
        private bool ilmoittautumisetIsCanceled = false;
        private readonly Dictionary<int, string> IlmoittautumisetFiles = [];
        private readonly Dictionary<int, VakLatIlmoittautumisetReader> IlmoittautumisetReaders = [];

        async Task OnIlmoittautumisetProgressChangeAsync(FluentInputFileEventArgs file)
        {
            Logger.LogWarning("OnIlmoittautumisetProgressChangeAsync: {0}", file.Name);
            ilmoittautumisetProgressPercent = file.ProgressPercent;
            ilmoittautumisetProgressTitle = file.ProgressTitle;

            // To cancel?
            file.IsCancelled = ilmoittautumisetIsCanceled;

            // New file
            if (!IlmoittautumisetFiles.ContainsKey(file.Index))
            {
                var localFile = Path.GetTempFileName() + file.Name;
                IlmoittautumisetFiles.Add(file.Index, localFile);
            }

            // Write to the FileStream
            await file.Buffer.AppendToFileAsync(IlmoittautumisetFiles[file.Index]);
        }

        void OnIlmoittautumisetCompleted()
        {
            Logger.LogWarning("OnIlmoittautumisetCompleted");
            ilmoittautumisetProgressPercent = ilmoittautumisetBuffer!.ProgressPercent;
            ilmoittautumisetProgressTitle = ilmoittautumisetBuffer!.ProgressTitle;

            foreach (var file in IlmoittautumisetFiles)
            {
                var ilmoittautumisetReader = new VakLatIlmoittautumisetReader(new MicrosoftLoggingAdapter(Logger));
                ilmoittautumisetReader.ReadRegisteredCouples(file.Value);
                File.Delete(file.Value);
            }
        }
    }
}
