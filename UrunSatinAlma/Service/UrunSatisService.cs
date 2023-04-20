using UrunSatinAlma.Context;
using UrunSatinAlma.Dtos;

namespace UrunSatinAlma.Service
{
    public class UrunSatisService
    {
        UrunSatisContext urunSatisContext = new UrunSatisContext();

        public string CategoryAddOrUpdate(CategoryRequestDto model)
        {
            var categoriesRepo = urunSatisContext.Categories.ToList();
            if (model.Id > 0)
            {
                var dbItem = categoriesRepo.Where(x => x.Id == model.Id).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.Name = model.Name;
                    dbItem.Order = model.Order;
                    urunSatisContext.SaveChanges();
                    return "Kategori Başarıyla Güncellendi.";
                }
            }

            var categorie = new Category();
            categorie.Order = model.Order;
            categorie.Name = model.Name;
            urunSatisContext.Add(categorie);
            urunSatisContext.SaveChanges();
            return "Kategori Başarıyla Eklendi.";
        }
        public string ProductAddOrUpdate(ProductRequestDto model)
        {
            var productRepo = urunSatisContext.Products.ToList();
            if (model.Id > 0)
            {
                var dbItem = productRepo.Where(x => x.Id == model.Id).FirstOrDefault();
                if (dbItem != null)
                {
                    dbItem.Name = model.Name;
                    dbItem.Detail = model.Detail;
                    dbItem.Price = model.Price;
                    dbItem.CategoryId = model.CategoryId;
                    dbItem.Image = model.Image;
                    dbItem.ShortDescription = model.ShortDescription;
                    urunSatisContext.SaveChanges();
                    return "Ürün başarıyla güncellendi";
                }
            }

            var product = new Products();
            product.Name = model.Name;
            product.Detail = model.Detail;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;
            product.Image = model.Image;
            product.ShortDescription = model.ShortDescription;
            urunSatisContext.Add(product);
            urunSatisContext.SaveChanges();
            return "Ürün başarıyla eklendi";
        }
        public string BasketAdd(BasketRequestDto model)
        {
            var basket = new Basket();
            var product = new Products();
            decimal totalPrice = 0;
            foreach (var item in model.Products)
            {
                product.Detail = item.Detail;
                product.Price = item.Price;
                product.CategoryId = item.CategoryId;
                product.Image = item.Image;
                product.ShortDescription = item.ShortDescription;
                product.Id = item.Id;
                basket.Products.Add(product);
                totalPrice += item.Price;
            }
            basket.TotalPrice = totalPrice;
            urunSatisContext.Add(basket);
            urunSatisContext.SaveChanges();
            return "Ürün Sepetinize Eklendi";
        }
        public string Register(UserRequestDto model)
        {
            var userRepo = urunSatisContext.Users.ToList();
            var userCheck = userRepo.Where(x => x.Email == model.Email).FirstOrDefault();
            if (userCheck != null)
            {
                return "Bu mail adresi daha önce kullanılıyor";
            }
            else
            {
                var user = new User();
                user.Password = model.Password;
                user.Email = model.Email;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.RoleId = model.RoleId;
                urunSatisContext.Add(user);
                urunSatisContext.SaveChanges();
                return "Kullanıcı başarıyla oluşturuldu.";

            }
        }
        public User? Login(LoginRequestDto model)
        {
            var userRepo = urunSatisContext.Users.ToList();
            var userCheck = userRepo.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            if (userCheck != null)
            {
                return userCheck;
            }
            else
            {
                return null;

            }
        }
        public List<Products> GetAllProducts(ProductFilterDto model)
        {
            if (!String.IsNullOrEmpty(model.GeneralSearch) && model.CategoryId > 0)
            {
                var lowerCase = model.GeneralSearch.ToLower();
                var prodCheck = urunSatisContext.Products.Where(x => x.Name.ToLower().Contains(lowerCase) && x.CategoryId == model.CategoryId).ToList();
                return prodCheck;
            }
            else if (!String.IsNullOrEmpty(model.GeneralSearch) && (model.CategoryId == 0 || model.CategoryId == null))
            {
                var lowerCase = model.GeneralSearch.ToLower();
                var prodCheck = urunSatisContext.Products.Where(x => x.Name.ToLower().Contains(lowerCase)).ToList();
                return prodCheck;
            }
            else if (String.IsNullOrEmpty(model.GeneralSearch) && model.CategoryId > 0)
            {
                var prodCheck = urunSatisContext.Products.Where(x => x.CategoryId == model.CategoryId).ToList();
                return prodCheck;
            }
            else
            {
                return urunSatisContext.Products.ToList();
            }
        }

        public List<Category> GetAllCategories()
        {
            return urunSatisContext.Categories.ToList();
        }
        public Products? GetProductById(long id)
        {
            var product = urunSatisContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product != null)
            {
                return product;
            }
            return null;
        }
        public string ProductDelete(long id)
        {
            var deletedProduct = urunSatisContext.Products.Where(x => x.Id == id).FirstOrDefault();
            if (deletedProduct != null)
            {
                urunSatisContext.Remove(deletedProduct);
                urunSatisContext.SaveChanges();
                return "Ürün başarıyla silindi.";
            }
            return "Ürün bulunamadı.";
        }
    }
}
