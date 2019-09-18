using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner.Models;
using SacramentPlanner_ErikMartinezAndDavidAruldass.Models;

namespace SacramentPlanner_ErikMartinezAndDavidAruldass.Controllers
{
    public class SacramentSchedulesController : Controller
    {
        private readonly Context _context;

        public SacramentSchedulesController(Context context)
        {
            _context = context;
        }

        // GET: SacramentSchedules
        public async Task<IActionResult> Index()
        {
            var context = 
                _context.SacramentSchedule
                .Include(s => s.Bishopric)
                .Include(s => s.ClosingHymn)
                .Include(s => s.IntermediateHymn)
                .Include(s => s.OpeningHymn)
                .Include(s => s.SacramentalHymn)
                .Include(s => s.Invocation)
                .Include(s => s.Benediction)
                .Include(s => s.OpeningSpeaker.Member)
                .Include(s => s.IntermediateSpeaker.Member)
                .Include(s => s.ClosingSpeaker.Member);
            return View(await context.ToListAsync());
        }

        // GET: SacramentSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentSchedule = await _context.SacramentSchedule
                .Include(s => s.Bishopric)
                .Include(s => s.ClosingHymn)
                .Include(s => s.IntermediateHymn)
                .Include(s => s.OpeningHymn)
                .Include(s => s.SacramentalHymn)
                .Include(s => s.Invocation)
                .Include(s => s.Benediction)
                .Include(s => s.OpeningSpeaker.Member)
                .Include(s => s.IntermediateSpeaker.Member)
                .Include(s => s.ClosingSpeaker.Member)
                .FirstOrDefaultAsync(m => m.SacramentScheduleId == id);
            if (sacramentSchedule == null)
            {
                return NotFound();
            }

            return View(sacramentSchedule);
        }

        // GET: SacramentSchedules/Create
        public IActionResult Create()
        {
            ViewData["BishopricId"] = new SelectList(_context.Bishopric, "BishopricId", "BishopricName");
            ViewData["ClosingHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName");
            ViewData["IntermediateHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName");
            ViewData["OpeningHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName");
            ViewData["SacramentalHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName");

            ViewData["InvocationId"] = new SelectList(_context.Member, "MemberId", "MemberName");
            ViewData["BenedictionId"] = new SelectList(_context.Member, "MemberId", "MemberName");

            //var speakers = _context.Speaker.Include(s => s.Member).ToList();

            //ViewData["OpeningSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName");
            //ViewData["IntermediateSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName");
            //ViewData["ClosingSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName");

            ViewData["OpeningSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName");
            ViewData["IntermediateSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName");
            ViewData["ClosingSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName");


            return View();
        }

        // POST: SacramentSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SacramentScheduleId,MeetingDate,BishopricId,OpeningHymnId,SacramentalHymnId,IntermediateHymnId,ClosingHymnId,FirstSpeakerId,SecondSpeakerId,ThirdSpeakerId,InvocationId,BenedictionId")] SacramentSchedule sacramentSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sacramentSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ////Is this needed?????
            //ViewData["BishopricId"] = new SelectList(_context.Bishopric, "BishopricId", "BishopricName", sacramentSchedule.BishopricId);
            //ViewData["ClosingHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.ClosingHymnId);
            //ViewData["IntermediateHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.IntermediateHymnId);
            //ViewData["OpeningHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.OpeningHymnId);
            //ViewData["SacramentalHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.SacramentalHymnId);

            //ViewData["InvocationId"] = new SelectList(_context.Member, "MemberId", "MemberName", sacramentSchedule.InvocationId);
            //ViewData["BenedictionId"] = new SelectList(_context.Member, "MemberId", "MemberName", sacramentSchedule.BenedictionId);

            ////ask about this
            //ViewData["OpeningSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName", sacramentSchedule.OpeningSpeakerId);
            //ViewData["IntermediateSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName", sacramentSchedule.IntermediateSpeakerId);
            //ViewData["ClosingSpeakerId"] = new SelectList(_context.Speaker, "SpeakerId", "Member.MemberName", sacramentSchedule.ClosingSpeakerId);

            return View(sacramentSchedule);
        }

        // GET: SacramentSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentSchedule = await _context.SacramentSchedule.FindAsync(id);
            if (sacramentSchedule == null)
            {
                return NotFound();
            }
            ViewData["BishopricId"] = new SelectList(_context.Bishopric, "BishopricId", "BishopricName", sacramentSchedule.BishopricId);
            ViewData["ClosingHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.ClosingHymnId);
            ViewData["IntermediateHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.IntermediateHymnId);
            ViewData["OpeningHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.OpeningHymnId);
            ViewData["SacramentalHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnName", sacramentSchedule.SacramentalHymnId);

            ViewData["InvocationId"] = new SelectList(_context.Member, "MemberId", "MemberName", sacramentSchedule.InvocationId);
            ViewData["BenedictionId"] = new SelectList(_context.Member, "MemberId", "MemberName", sacramentSchedule.BenedictionId);

            var speakers = _context.Speaker.Include(s => s.Member).ToList();

            ViewData["OpeningSpeakerId"] = new SelectList(speakers, "SpeakerId", "Member.MemberName", sacramentSchedule.OpeningSpeakerId);
            ViewData["IntermediateSpeakerId"] = new SelectList(speakers, "SpeakerId", "Member.MemberName", sacramentSchedule.IntermediateSpeakerId);
            ViewData["ClosingSpeakerId"] = new SelectList(speakers, "SpeakerId", "Member.MemberName", sacramentSchedule.ClosingSpeakerId);

            return View(sacramentSchedule);
        }

        // POST: SacramentSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SacramentScheduleId,MeetingDate,BishopricId,OpeningHymnId,SacramentalHymnId,IntermediateHymnId,ClosingHymnId,FirstSpeakerId,SecondSpeakerId,ThirdSpeakerId,InvocationId,BenedictionId")] SacramentSchedule sacramentSchedule)
        {
            if (id != sacramentSchedule.SacramentScheduleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sacramentSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SacramentScheduleExists(sacramentSchedule.SacramentScheduleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            //needed?
            ViewData["BishopricId"] = new SelectList(_context.Bishopric, "BishopricId", "BishopricId", sacramentSchedule.BishopricId);
            ViewData["ClosingHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnId", sacramentSchedule.ClosingHymnId);
            ViewData["IntermediateHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnId", sacramentSchedule.IntermediateHymnId);
            ViewData["OpeningHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnId", sacramentSchedule.OpeningHymnId);
            ViewData["SacramentalHymnId"] = new SelectList(_context.Hymn, "HymnId", "HymnId", sacramentSchedule.SacramentalHymnId);

            ViewData["InvocationId"] = new SelectList(_context.Member, "MemberId", "MemberName", sacramentSchedule.InvocationId);
            ViewData["BenedictionId"] = new SelectList(_context.Member, "MemberId", "MemberName", sacramentSchedule.BenedictionId);

            var speakers = _context.Speaker.Include(s => s.Member).ToList();
            //ask about this
            ViewData["OpeningSpeakerId"] = new SelectList(speakers, "SpeakerId", "Member.MemberName", sacramentSchedule.OpeningSpeakerId);
            ViewData["IntermediateSpeakerId"] = new SelectList(speakers, "SpeakerId", "SpeakerId", sacramentSchedule.IntermediateSpeakerId);
            ViewData["ClosingSpeakerId"] = new SelectList(speakers, "SpeakerId", "SpeakerId", sacramentSchedule.ClosingSpeakerId);

            return View(sacramentSchedule);
        }

        // GET: SacramentSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sacramentSchedule = await _context.SacramentSchedule
                .Include(s => s.Bishopric)
                .Include(s => s.ClosingHymn)
                .Include(s => s.IntermediateHymn)
                .Include(s => s.OpeningHymn)
                .Include(s => s.SacramentalHymn)
                .Include(s => s.Invocation)
                .Include(s => s.Benediction)
                .Include(s => s.OpeningSpeaker.Member)
                .Include(s => s.IntermediateSpeaker.Member)
                .Include(s => s.ClosingSpeaker.Member)
                .FirstOrDefaultAsync(m => m.SacramentScheduleId == id);
            if (sacramentSchedule == null)
            {
                return NotFound();
            }

            return View(sacramentSchedule);
        }

        // POST: SacramentSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sacramentSchedule = await _context.SacramentSchedule.FindAsync(id);
            _context.SacramentSchedule.Remove(sacramentSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SacramentScheduleExists(int id)
        {
            return _context.SacramentSchedule.Any(e => e.SacramentScheduleId == id);
        }
    }
}
