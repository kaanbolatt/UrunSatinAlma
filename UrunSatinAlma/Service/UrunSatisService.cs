using UrunSatinAlma.Context;
using UrunSatinAlma.Dtos;
using UrunSatinAlma.Migrations;

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
            var eklenenUrun = urunSatisContext.Products.Where(x => x.Id == model.ProductId).FirstOrDefault();

            if (eklenenUrun == null)
            {
                return "Böyle bir ürün satışta yok.";
            }

            var basket = new Basket();
            basket.UserId = model.UserId;
            basket.ProductId = eklenenUrun.Id;
            urunSatisContext.Add(basket);
            urunSatisContext.SaveChanges();
            return "Ürün sepetinize eklendi.";
        }
        public List<BasketResponseDto> GetBasketList(long userId)
        {
            var basketRepo = urunSatisContext.Baskets.Where(x => x.UserId == userId).ToList();
            var productRepo = urunSatisContext.Products.ToList();
            var query = (from basket in basketRepo
                         join product in productRepo on basket.ProductId equals product.Id
                         select new BasketResponseDto { ProductName = product.Name, ProductPrice = product.Price, ProductImage = product.Image, BasketId = basket.Id }).ToList();

            return query;
        }
        public string BasketProductDelete(long id)
        {
            var deletedBasketItem = urunSatisContext.Baskets.Where(x => x.Id == id).FirstOrDefault();
            if (deletedBasketItem != null)
            {
                urunSatisContext.Remove(deletedBasketItem);
                urunSatisContext.SaveChanges();
                return "Ürün sepetinizden kaldırıldı.";
            }
            return "Sepet bulunamadı.";
        }

        public string AllBasketProductDelete(long userId)
        {
            var deletedBasketItem = urunSatisContext.Baskets.Where(x => x.UserId == userId).ToList();
            foreach (var basket in deletedBasketItem)
            {
                urunSatisContext.Remove(basket);
                urunSatisContext.SaveChanges();
            }
          
            return "Sepetinizdeki tüm ürünler kaldırıldı.";
        }
        public string Register(UserRequestDto model)
        {
            var userRepo = urunSatisContext.Users.ToList();
            var userCheck = userRepo.Where(x => x.Email == model.Email).FirstOrDefault();
            if (userCheck != null)
            {
                return "Bu mail adresi daha önce kullanılmış";
            }
            else
            {
                var user = new User();
                user.Password = model.Password;
                user.Email = model.Email;
                user.RoleId = 1;
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

        public string CategoryDelete(long id)
        {
            var deletedCategory = urunSatisContext.Categories.Where(x => x.Id == id).FirstOrDefault();
            if (deletedCategory != null)
            {
                urunSatisContext.Remove(deletedCategory);
                urunSatisContext.SaveChanges();
                return "Kategori başarıyla silindi.";
            }
            return "Kategori bulunamadı.";
        }
    }
}
