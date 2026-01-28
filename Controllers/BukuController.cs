using Microsoft.AspNetCore.Mvc;
using tesAsprak.Models;

namespace tesAsprak.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BukuController : ControllerBase
    {
        private Buku buku;
        private static List<Buku> _bukusiswaList =
        [
            new Buku(1, "Literasi KPL", "Mochammad Syaifuddin Zuhri", 2023, true),
        ];

        // GET: api/mahasiswa
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bukusiswaList);
        }

        // GET: api/mahasiswa/{index}
        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            if (index < 0 || index >= _bukusiswaList.Count)
            {
                return NotFound("Buku not found");
            }

            return Ok(_bukusiswaList[index]);
        }

        // POST: api/mahasiswa
        [HttpPost]
        public IActionResult Post([FromBody] Buku buku)
        {
            _bukusiswaList.Add(buku);
            Buku.AddJSON(buku, "103022300057.json");
            return CreatedAtAction(nameof(Get), new { index = _bukusiswaList.Count - 1 }, buku);
        }

        // PUT: api/mahasiswa/{index}
        [HttpPut("{index}")]
        public IActionResult Put(int index, [FromBody] Buku buku)
        {
            if (index < 0 || index >= _bukusiswaList.Count)
            {
                return NotFound("Buku not found");
            }
            _bukusiswaList.Add(buku);
            Buku.AddJSON(buku, "103022300057.json");
            return CreatedAtAction(nameof(Put), new { index = _bukusiswaList.Count - 1 }, buku);
        }

        // DELETE: api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= _bukusiswaList.Count)
            {
                return NotFound("Mahasiswa not found");
            }

            _bukusiswaList.RemoveAt(index);
            Buku.AddJSON(buku, "103022300057.json");
            return NoContent();
        }
    }
}