using System;
using Yaba.Tools.Validations;

namespace Avalivre.Domain.Products
{
    public class Product
    {
        public Product(string name, string brand)
        {
            ValidateName(name);
            ValidateBrand(brand);

            this.Name = name;
            this.CreationDate = DateTime.Now; // TODO: localizar para o brasil
            this.Brand = brand;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public string Brand { get; private set; }
        public string ModelCode { get; private set; }
        public string Material { get; private set; }


        public void SetName(string name)
        {
            ValidateName(name);
            this.Name = name;
        }

        public void SetBrand(string brand)
        {
            ValidateBrand(brand);
            this.Brand = brand;
        }

        public void SetModelCode(string modelCode)
        {
            ValidateModelCode(modelCode);
            this.ModelCode = modelCode;
        }

        public void SetMaterial(string material)
        {
            ValidateMaterial(material);
            this.Material = material;
        }

        #region Priv Methods
        private void ValidateName(string name)
        {
            Validate.NotNullOrEmpty(name, "O nome do produto é necessário.");
        }

        private void ValidateBrand(string brand)
        {
            Validate.NotNullOrEmpty(brand, "A marca do produto é necessário.");
        }

        private void ValidateModelCode(string modelCode)
        {
            Validate.NotNullOrEmpty(modelCode, "O nome do modelo está inválido.");
        }

        private void ValidateMaterial(string material)
        {
            Validate.NotNullOrEmpty(material, "O nome do material está inválido.");
        }

        #endregion

    }
}
