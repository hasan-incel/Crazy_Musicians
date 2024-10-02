using Crazy_Musicians.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crazy_Musicians.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusiciansController : ControllerBase
    {
        private static List<Musician> musicians = new List<Musician>
    {
        new Musician { Id = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunFeature = "Her zaman yanlış nota çalar, ama çok eğlenceli." },
        new Musician { Id = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunFeature = "Şarkıları yanlış anlaşılır ama çok popüler." },
        new Musician { Id = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist", FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli." },
        new Musician { Id = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi", FunFeature = "Nota üretirken sürekli sürpriz hazırlar." },
        new Musician { Id = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı", FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir." },
        new Musician { Id = 6, Name = "Elif Armoni", Profession = "Armoni Ustası", FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır." },
        new Musician { Id = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı", FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir." },
        new Musician { Id = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı", FunFeature = "Rezonans konusunda uzman, ama bazen çok gürültü çıkarır." },
        new Musician { Id = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı", FunFeature = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç." },
        new Musician { Id = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı", FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır." }
    };

        // Get all musicians
        [HttpGet]
        public ActionResult<List<Musician>> GetAll()
        {
            return Ok(musicians);
        }

        // Get a musician by ID
        [HttpGet("{id}")]
        public ActionResult<Musician> GetById(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            return musician != null ? Ok(musician) : NotFound();
        }

        // Search musicians by name
        [HttpGet("search")]
        public ActionResult<List<Musician>> Search([FromQuery] string name)
        {
            var result = musicians.Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(result);
        }

        // Add a new musician
        [HttpPost]
        public ActionResult<Musician> Create(Musician musician)
        {
            musician.Id = musicians.Max(m => m.Id) + 1;
            musicians.Add(musician);
            return CreatedAtAction(nameof(GetById), new { id = musician.Id }, musician);
        }

        // Update an existing musician
        [HttpPut("{id}")]
        public ActionResult Update(int id, Musician musician)
        {
            var existingMusician = musicians.FirstOrDefault(m => m.Id == id);
            if (existingMusician == null) return NotFound();
            existingMusician.Name = musician.Name;
            existingMusician.Profession = musician.Profession;
            existingMusician.FunFeature = musician.FunFeature;
            return NoContent();
        }

        // Partially update a musician
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, [FromBody] Musician updatedMusician)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null) return NotFound();

            // Update only the properties that are not null
            if (!string.IsNullOrEmpty(updatedMusician.Name))
                musician.Name = updatedMusician.Name;

            if (!string.IsNullOrEmpty(updatedMusician.Profession))
                musician.Profession = updatedMusician.Profession;

            if (!string.IsNullOrEmpty(updatedMusician.FunFeature))
                musician.FunFeature = updatedMusician.FunFeature;

            return NoContent();
        }


        // Delete a musician
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var musician = musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null) return NotFound();
            musicians.Remove(musician);
            return NoContent();
        }
    }

}
