using Data_Logic_Layer;
using Data_Logic_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BALCMS
    {
        private readonly DALCMS _dalCMS;

        public BALCMS(DALCMS dalCMS)
        {
            _dalCMS = dalCMS;
        }

        public List<CMS> GetCMSList()
        {
            return _dalCMS.GetCMSList();
        }

        public List<CMS> GetCMSById(int id)
        {
            return _dalCMS.GetCMSById(id);
        }

        public async Task<string> AddCMS(CMS cms)
        {
            return await _dalCMS.AddCMS(cms);
        }

        public async Task<string> UpdateCMS(int id, CMS cms)
        {
            return await _dalCMS.UpdateCMS(id, cms);
        }

        public async Task<string> DeleteCMS(int id)
        {
            return await _dalCMS.DeleteCMS(id);
        }
    }
}
