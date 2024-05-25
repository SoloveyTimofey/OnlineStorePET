using ManagementApplication.Models;
using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Proxy;
using ManagementApplication.StaticFiles;
using Microsoft.Win32;
using StoreDataModels;
using StoreDataModels.Clothes;
using StoreDataModels.DTO;
using StoreDataModels.DTO.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ManagementApplication.MVVM.ViewModels.Actions.CLothingVM
{
    public class CreateClothingViewModel : ActionBaseVM<Clothing>
    {
        private ClothingRepositoryProxy clothingRepositoryProxy;
        private GeneralRepositoryProxy generalRepositoryProxy;
        private string defaultImagePath = "pack://application:,,,/ManagementApplication;component/Icons/defaultImage.png";
        public CreateClothingViewModel(ClothingRepositoryProxy clothingRepositoryProxy, GeneralRepositoryProxy generalRepositoryProxy) : base("Create", "clothing")
        {
            this.clothingRepositoryProxy = clothingRepositoryProxy;
            this.generalRepositoryProxy = generalRepositoryProxy;

            SetDefaultSettings();
        }

        #region Properties
        private string imagePath { get; set; }
        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                OnPropertyChanged();
            }
        }

        private string selectedGender { get; set; }
        public string SelectedGender
        {
            get => selectedGender;
            set
            {
                selectedGender = value;
                OnPropertyChanged();
            }
        }

        private Color? selectedColor { get; set; }
        public Color? SelectedColor
        {
            get => selectedColor;
            set
            {
                selectedColor = value;
                OnPropertyChanged();
            }
        }

        private Brand? selectedBrand { get; set; }
        public Brand? SelectedBrand
        {
            get => selectedBrand;
            set
            {
                selectedBrand = value;
                OnPropertyChanged();
            }
        }

        private Category? selectedCategory { get; set; }
        public Category? SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        private Fit selectedFit { get; set; }
        public Fit SelectedFit
        {
            get => selectedFit;
            set
            {
                selectedFit = value;
                OnPropertyChanged();
            }
        }

        private SleeveLenght? selectedSleeveLenght { get; set; }
        public SleeveLenght? SelectedSleeveLenght
        {
            get => selectedSleeveLenght;
            set
            {
                selectedSleeveLenght = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Brand> brands { get; set; }
        public IEnumerable<Brand> Brands
        {
            get => brands;
            set
            {
                brands = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Color> colors { get; set; }
        public IEnumerable<Color> Colors
        {
            get => colors;
            set
            {
                colors = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Category> categories { get; set; }
        public IEnumerable<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<Fit> fits { get; set; }
        public IEnumerable<Fit> Fits
        {
            get => fits;
            set
            {
                fits = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<SleeveLenght> sleeveLenghts { get; set; }
        public IEnumerable<SleeveLenght> SleeveLenghts
        {
            get => sleeveLenghts;
            set
            {
                sleeveLenghts = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<ExtendedClothingSize> clothingSizes { get; set; }
        public ObservableCollection<ExtendedClothingSize> ClothingSizes
        {
            get => clothingSizes;
            set
            {
                clothingSizes = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<string> genders { get; set; }
        public IEnumerable<string> Genders
        {
            get => genders ?? new List<string>
            {
                "Male",
                "Female",
                "Unisex"
            };
        }
        #endregion

        #region Commands
        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (ValidateForm()==false)
                {
                    return;
                }

                var clthToAdd = new ClothingDTO
                {
                    Name = TargetModel.Name,
                    CategoryId = SelectedCategory!.Id,
                    Price = TargetModel.Price,
                    Gender = GetGender(SelectedGender),
                    ImageBytes = ImageToBytesConverter.ImageToBytes(ImagePath),
                    BrandId = SelectedBrand!.Id,
                    ColorId = SelectedColor!.Id,
                    FitId = SelectedFit?.Id,
                    SleeveLenghtId = SelectedSleeveLenght?.Id
                };

                var clthResult = await clothingRepositoryProxy.CreateClothingAsync(clthToAdd);

                Clothing clth = clthResult.Item1;

                List<ClothingSizeJunctionDTO> clothingSizeJunctionDTOs = new List<ClothingSizeJunctionDTO>();
                foreach (ExtendedClothingSize cs in ClothingSizes.Where(cs=>cs.IsIncluded==true))
                {
                    ClothingSizeJunctionDTO csj = new ClothingSizeJunctionDTO
                    {
                        ClothingId = clth.Id,
                        ClothingSizeId = cs.Id,
                        Quantity = cs.Count
                    };
                    clothingSizeJunctionDTOs.Add(csj);
                }

                var csjResult= await clothingRepositoryProxy.AddRangeSizeToClothingAsync(clothingSizeJunctionDTOs);

                if (csjResult.Item2==HttpStatusCode.OK&&clthResult.Item2==HttpStatusCode.OK)
                {
                    IsActionSuccessful = true;

                    TargetModel = new Clothing();
                    SelectedCategory = null;
                    SelectedGender = string.Empty;
                    SelectedBrand = null;
                    SelectedColor = null;
                    SelectedFit = null;
                    SelectedSleeveLenght = null;
                    foreach (var cs in ClothingSizes)
                    {
                        cs.IsIncluded = false;
                        cs.Count = 0;
                    }
                }
            });
        }

        private RelayCommand selectImage { get; set; }
        public RelayCommand SelectImage
        {
            get => selectImage ?? new RelayCommand(obj =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                {
                    string imagePath = openFileDialog.FileName;
                    BitmapImage bitmap = new BitmapImage(new Uri(imagePath));
                    ImagePath = imagePath;
                }
            });
        }

        private RelayCommand clothingWindowActivated { get; set; }
        public RelayCommand ClothingWindowActivated
        {
            get => clothingWindowActivated ?? new RelayCommand(async obj =>
            {
                var ctgrs = await clothingRepositoryProxy.GetAllClothingCategoriesAsync();
                Categories = ctgrs.Item1;

                var brnds = await generalRepositoryProxy.GetAllBrandsAsync();
                Brands = brnds.Item1;

                var clrs = await generalRepositoryProxy.GetAllColorsAsync();
                Colors = clrs.Item1;

                var fts = await clothingRepositoryProxy.GetAllFitsAsync();
                Fits = fts.Item1;

                var slvLnghts = await clothingRepositoryProxy.GetAllSleeveLenghtsAsync();
                SleeveLenghts = slvLnghts.Item1;

                var clthSzs = await clothingRepositoryProxy.GetAllClothingSizesAsync();
                ClothingSizes = new ObservableCollection<ExtendedClothingSize>(clthSzs.Item1.Select(cs => new ExtendedClothingSize(cs.Id, cs.Size)));
            });
        }
        #endregion

        private void SetDefaultSettings()
        {
            ImagePath = defaultImagePath;
            TargetModel = new Clothing();
        }

        private bool ValidateForm()
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(TargetModel.Name))
            {
                stringBuilder.AppendLine("• Clothing Name cannot be empty.");
            }
            if (SelectedCategory==null)
            {
                stringBuilder.AppendLine("• Select Category.");
            }
            if (TargetModel.Price<0||TargetModel.Price==0)
            {
                stringBuilder.AppendLine("• Invalid Price.");
            }
            if (String.IsNullOrEmpty(SelectedGender))
            {
                stringBuilder.AppendLine("• Select Gender.");
            }
            if (SelectedBrand == null)
            {
                stringBuilder.AppendLine("• Select Brand.");
            }
            if (SelectedColor==null)
            {
                stringBuilder.AppendLine("• Select Color.");
            }
            if (ImagePath == defaultImagePath)
            {
                stringBuilder.AppendLine("• Select Image.");
            }
            if (selectedFit==null)
            {
                stringBuilder.AppendLine("• Select Fit.");
            }

            foreach (ExtendedClothingSize cs in ClothingSizes)
            {
                if (cs.IsIncluded&&cs.Count<1)
                {
                    stringBuilder.AppendLine($"• Select number for {cs.Size} Size.");
                }
            }

            ErrorMessage = stringBuilder.ToString();
            if (String.IsNullOrEmpty(ErrorMessage))
            {
                return true;
            }
            else
            {
                ErrorMessage = stringBuilder.ToString();
                return false;
            }
        }

        private Gender GetGender(string gender)
        {
            Gender gndr;

            switch (gender)
            {
                case "Male":
                    gndr = Gender.Male;
                    break;
                case "Female":
                    gndr = Gender.Female;
                    break;
                case "Unisex":
                    gndr = Gender.Unisex;
                    break;
                default:
                    throw new ArgumentException(nameof(gender));
            }

            return gndr;
        }
    }
}
