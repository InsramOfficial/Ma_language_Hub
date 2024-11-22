using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.OurProfessionalDetails
{
    public class EditProfessionalModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;

        public OurProfessionals professional {  get; set; }
        public EditProfessionalModel(MALHdbcontext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void OnGet(int id)
        {
            professional = db.tbl_ourprofessionals.Where(x => x.Id == id).FirstOrDefault();
        }
        public IActionResult OnPost(OurProfessionals professional)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                OurProfessionals update = new();
                update.Id = professional.Id;
                update.Title = professional.Title;
                update.Description = professional.Description;
                update.FacebookLink = professional.FacebookLink;
                update.InstagramLink = professional.InstagramLink;
                update.LinkedInLink = professional.LinkedInLink;
                update.WhatsAppLink = professional.WhatsAppLink;

                if(professional.Image == null)
                {
                    update.ImageName = professional.ImageName;

                }
                else
                {
                    update.ImageName = professional.Image.FileName;
                    var folderpath = Path.Combine(env.WebRootPath, "images");
                    var imagepath = Path.Combine(folderpath, professional.Image.FileName);
                    professional.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
                }
                db.tbl_ourprofessionals.Update(update);
                db.SaveChanges();
            }
            return RedirectToPage("index");
        }
    }
}
