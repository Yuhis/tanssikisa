using AntDesign;
using AutoMapper;
using Integration.DanceCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Tanssikisa.BlazorApp.Integrations.DanceCore
{
    public partial class TuoVakLatIlmoittautumiset
    {
        [Inject]
        protected ILogger<TuoVakLatIlmoittautumiset> Logger { get; set; }
        [Inject]
        private IMapper Mapper { get; set; }
        
        private string fileName { get; set; } = "";
        protected VakLatIlmoittautuminen[] ilmoittautumiset;
        protected VakLatIlmoittautuminenModal vakLatIlmoittautuminenModal;

        private async Task OnInputFileChange(InputFileChangeEventArgs eventArgs)
        {
            fileName = eventArgs.File.Name;
            Console.WriteLine($"Got input file: {fileName}");

            using var fileStream = eventArgs.File.OpenReadStream();
            using var memoryStream = new MemoryStream();
            await fileStream.CopyToAsync(memoryStream);

            var reader = new VakLatIlmoittautumisetReader(new MicrosoftLoggingAdapter(Logger));
            reader.ReadRegisteredCouples(memoryStream);

            ilmoittautumiset = new VakLatIlmoittautuminen[reader.DanceCoreIlmoittautumiset.Count];
            int idx = 0;
            foreach (var i in reader.DanceCoreIlmoittautumiset)
            {
                ilmoittautumiset[idx] = Mapper.Map<VakLatIlmoittautuminen>(i);
                idx++;
            }
            StateHasChanged();
        }

        private Task MuokkaaVakLatIlmoittautuminen(int rowNumber)
        {
            Console.WriteLine($"Modify row number: {rowNumber}");

            vakLatIlmoittautuminenModal._visible = true;
            StateHasChanged();

            return Task.CompletedTask;
        }
    }
}
