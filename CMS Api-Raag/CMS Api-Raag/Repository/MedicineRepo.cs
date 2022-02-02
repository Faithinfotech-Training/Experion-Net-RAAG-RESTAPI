using CMS_Api_Raag.Models;
using CMS_Api_Raag.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Api_Raag.Repository
{
    public class MedicineRepo : IMedicineRepo
    {
        private readonly CMSDBContext _context;
        public MedicineRepo(CMSDBContext context)
        {
            _context = context;
        }

        //view Medicine Details
        #region Get Medicines
        public async Task<List<Medicine>> GetMedicines()
        {

            if (_context != null)
            {
                return await _context.Medicine.Include(a => a.Admin).ToListAsync();
            }
            return null;
        }
        #endregion


        //Add Medicine Detais
        #region Add Medicine
        public async Task<int> AddMedicine(Medicine medicine)
        {
            if (_context != null)
            {
                await _context.Medicine.AddAsync(medicine);
                await _context.SaveChangesAsync();
                return medicine.MedicineId;
            }
            return 0;
        }
        #endregion


        //view all medicines  --view Model
        #region view Medicines
        public async Task<List<MedicineViewModel>> GetAllMedicines()
        {
            if (_context != null)
            {
                return await (from m in _context.Medicine
                              from a in _context.Admin
                              where a.AdminId == m.AdminId
                              select new MedicineViewModel
                              {
                                  MedicineId = m.MedicineId,
                                  MedicineName = m.MedicineName,
                                  StockQuantity = m.StockQuantity,
                                  UnitPrice = m.UnitPrice,
                                  ExpiryDate = m.ExpiryDate,
                                  AdminId = a.AdminId
                              }
                              ).ToListAsync();

            }
            return null;
        }
        #endregion


        //get medicine by medicine name  --viewModel
        #region Get Medicine by Name
        public async Task<MedicineViewModel> GetMedicineByName(string name)
        {

            if (_context != null)
            {
                return await (from m in _context.Medicine
                              from a in _context.Admin
                              where m.MedicineName == name &
                               m.AdminId == a.AdminId
                              select new MedicineViewModel
                              {
                                  MedicineId = m.MedicineId,
                                  MedicineName = m.MedicineName,
                                  StockQuantity = m.StockQuantity,
                                  UnitPrice = m.UnitPrice,
                                  ExpiryDate = m.ExpiryDate,
                                  AdminId = a.AdminId
                              }).FirstOrDefaultAsync();

            }
            return null;
        }
        #endregion



        //Update a medicine details
        #region update Medicines
        public async Task UpdateMedicine(Medicine medicine)
        {
            if (_context != null)
            {
                _context.Entry(medicine).State = EntityState.Modified;
                _context.Medicine.Update(medicine);
                await _context.SaveChangesAsync();
            }
        }
        #endregion


        //Delete a Medicine
        #region delete
        public async Task<int> DeleteMedicine(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var medi = await _context.Medicine.FirstOrDefaultAsync(med => med.MedicineId == id);

                //check condition
                if (medi != null)
                {
                    //delete
                    _context.Medicine.Remove(medi);

                    //commit
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }


        #endregion

    }
}
