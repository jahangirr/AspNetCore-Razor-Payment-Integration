using JafEcomRCL.DAL;
using JafEcomRCL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JafEcomRCL.Services
{
    public interface IItem
    {
         Item getItem();
    }

    public class ItemService : IItem
    {
        private JafEcomRCLDbContext _JafEcomRCLDbContext;
        public ItemService(JafEcomRCLDbContext JafEcomRCLDbContext)
        {
            _JafEcomRCLDbContext = JafEcomRCLDbContext;

            try
            {
                if (!_JafEcomRCLDbContext.Item.Any())
                {
                    _JafEcomRCLDbContext.Database.EnsureCreated();
                }
            }
            catch (Exception ex)
            {
                _JafEcomRCLDbContext.Database.EnsureCreated();
                             
            }
        }
        public  Item getItem()
        {
            return _JafEcomRCLDbContext.Item.FirstOrDefault();
        }
    }
}
