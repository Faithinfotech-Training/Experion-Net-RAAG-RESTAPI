using CMS_Api_Raag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class LabTestRepository : IlabTestRepository
    {
        // Data fields
        private readonly CMSDBContext _context;

        // default constructor
        public LabTestRepository(CMSDBContext context)
        {
            _context = context;
        }
        public async Task<int> AddToTestBill(TestBill testbill)
        {
            if (_context != null)
            {
                await _context.TestBill.AddAsync(testbill);
                await _context.SaveChangesAsync(); // commit transaction
                return testbill.TbillId;
            }
            return 0;
        }

        public async Task<List<TestBill>> GetAllTestBills()
        {
            if (_context != null)
            {
                return await _context.TestBill.ToListAsync();
            }
            return null;
        }

        public async Task<ActionResult<TestBill>> GetTestBillById(int? id)
        {
            if (_context != null)
            {
                var bill = await _context.TestBill.FindAsync(id);
                return bill;
            }
            return null;
        }
    }
}
