using SNI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SNI.Controllers
{
    class TypeController
    {
        private static DataTable loadtypes(List<Types> listtypes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Số");
            dt.Columns.Add("Loại");
            dt.Columns.Add("Ngày Thêm");
            foreach (Types types in listtypes)
            {
                DataRow dtr = dt.NewRow();
                dtr["Mã Số"] = types.typeid;
                dtr["Loại"] = types.name;
                dtr["Ngày Thêm"] = types.dayadd.Hour + ":" + types.dayadd.Minute + "-" + types.dayadd.Day + "/" + types.dayadd.Month + "/" + types.dayadd.Year;
                dt.Rows.Add(dtr);
            }
            return dt;

        }
        public static Types addedtypes;
        public static bool addType(string type)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    int check = context.Types.Where(o => o.name.Trim() == type.Trim()).Count();
                    if (check == 0)
                    {
                        var ty = new Types
                        {
                            name = type,
                            available = true,
                            dayadd = DateTime.Now,
                            dayupdate = DateTime.Now
                        };
                        context.Types.Add(ty);
                        context.SaveChanges();
                        addedtypes = ty;
                        return true;
                    }
                    else
                    {
                        var gettype= context.Types.Where(o => o.name.Trim() == type.Trim()).FirstOrDefault();
                        gettype.available = true;
                        context.SaveChanges();
                        addedtypes = gettype;
                        return true;
                    }
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }
        public static DataTable loadTypeWithUpdate(List<Types> listtype)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Mã Số");
                    dt.Columns.Add("Loại");
                    dt.Columns.Add("Ngày Xóa");
                    foreach (Types types in listtype)
                    {
                        DataRow dtr = dt.NewRow();
                        dtr["Mã Số"] = types.typeid;
                        dtr["Loại"] = types.name;
                        dtr["Ngày Xóa"] = types.dayupdate.Hour + ":" + types.dayupdate.Minute + "-" + types.dayupdate.Day + "/" + types.dayupdate.Month + "/" + types.dayupdate.Year;
                        dt.Rows.Add(dtr);
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
        public static DataTable getRemovedType()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var listhealth = context.Types.Where(o => o.available == false).OrderByDescending(health => health.dayadd).Take(10).ToList();
                    return loadTypeWithUpdate(listhealth);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }
        public static DataTable FindType(string find)
        {
            using (var context = new ControllerModel())
            {
                var listtype = context.Types.Where(o => o.available == true && o.name.Contains(find)).Take(10).ToList();
                return loadtypes(listtype);
            }
        }
        public static bool Recovery(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var type = context.Types.Where(o => o.typeid == id).FirstOrDefault();
                    type.available = true;
                    type.dayupdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public static bool RemoveType(int id)
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var type = context.Types.Where(o => o.typeid == id).FirstOrDefault();
                    type.available = false;
                    type.dayupdate = DateTime.Now;
                    context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }
        public static DataTable getListType()
        {
            using (var context = new ControllerModel())
            {
                try
                {
                    var listtypes = context.Types.Where(health => health.available == true).OrderByDescending(health => health.dayadd).Take(10).ToList();
                    return loadtypes(listtypes);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

    }
}
