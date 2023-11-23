using Acr.UserDialogs;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.EntityModels;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class GioiThieuPageViewModel : ViewModelBase
    {
        private string _vanBanGioiThieu;
        public string VanBanGioiThieu
        {
            get { return _vanBanGioiThieu; }
            set
            {
                if (_vanBanGioiThieu != value)
                {
                    _vanBanGioiThieu = value;
                    OnPropertyChanged(nameof(VanBanGioiThieu));
                }
            }
        }

        private string _chucNang;
        public string ChucNang
        {
            get { return _chucNang; }
            set
            {
                if (_chucNang != value)
                {
                    _chucNang = value;
                    OnPropertyChanged(nameof(ChucNang));
                }
            }
        }
        private string _daoTao;
        public string DaoTao
        {
            get { return _daoTao; }
            set
            {
                if (_daoTao != value)
                {
                    _daoTao = value;
                    OnPropertyChanged(nameof(DaoTao));
                }
            }
        }
        private string _nghienCuu;
        public string NghienCuu
        {
            get { return _nghienCuu; }
            set
            {
                if (_nghienCuu != value)
                {
                    _nghienCuu = value;
                    OnPropertyChanged(nameof(NghienCuu));
                }
            }
        }
        private string _diaChi;
        public string DiaChi
        {
            get { return _diaChi; }
            set
            {
                if (_diaChi != value)
                {
                    _diaChi = value;
                    OnPropertyChanged(nameof(DiaChi));
                }
            }
        }

        IUserService iUserService;
        public DelegateCommand GotoDuKienDiemPopupCommand { get; private set; }

        public GioiThieuPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            VanBanGioiThieu = "Học viện Công nghệ Bưu chính Viễn thông được thành lập theo quyết định số 516/TTg của Thủ tướng Chính phủ ngày 11 tháng 7 năm 1997 trên cơ sở sắp xếp lại 4 đơn vị thành viên thuộc Tổng Công ty Bưu chính Viễn thông Việt Nam, nay là Tập đoàn Bưu chính Viễn thông Việt Nam là Viện Khoa học Kỹ thuật Bưu điện, Viện Kinh tế Bưu điện, Trung tâm đào tạo Bưu chính Viễn thông 1 và 2. Các đơn vị tiền thân của Học viện là những đơn vị có bề dày lịch sử hình thành và phát triển với xuất phát điểm từ Trường Đại học Bưu điện 1953.\r\n\r\nTừ ngày 1/7/2014, thực hiện Quyết định của Thủ tướng Chính phủ, Bộ trưởng Bộ Thông tin và Truyền thông đã ban hành Quyết định số 878/QĐ-BTTTT điều chuyển quyền quản lý Học viện từ Tập đoàn Bưu chính Viễn thông Việt Nam về Bộ Thông tin và Truyền thông. Học viện Công nghệ Bưu chính Viễn thông là đơn vị sự nghiệp trực thuộc Bộ. Là trường đại học, đơn vị nghiên cứu, phát triển nguồn nhân lực trọng điểm của Ngành thông tin và truyền thông.\r\n\r\nVới vị thế là đơn vị đào tạo, nghiên cứu trọng điểm, chủ lực của Ngành thông tin và truyền thông  Việt Nam, là trường đại học trọng điểm quốc gia trong lĩnh vực ICT, những thành tựu trong gắn kết giữa Nghiên cứu – Đào tạo – Sản xuất kinh doanh năng lực, quy mô phát triển của Học viện hôm nay, Học viện sẽ có những đóng góp hiệu quả phục vụ sự phát triển chung của Ngành Thông tin và truyền thông và sự nghiệp xây dựng, bảo vệ tổ quốc, góp phần để đất nước, để Ngành Thông tin và truyền thông Việt Nam có sự tự chủ, độc lập về khoa học công nghệ và nguồn nhân lực, qua đó tự tin cạnh tranh với các đối thủ lớn và sánh vai với các cường quốc trên thế giới.";
            ChucNang = "Học viện Công nghệ Bưu chính – Viễn thông là đơn vị sự nghiệp trực thuộc Bộ Thông tin và truyền thông, Học viện thực hiện hai chức năng cơ bản:\r\nGiáo dục, đào tạo cho xã hội và cho nhu cầu của Ngành thông tin và truyền thông Việt Nam.\r\nNghiên cứu khoa học, tư vấn, chuyển giao công nghệ trong lĩnh vực Bưu chính, Viễn thông và công nghệ thông tin đáp ứng nhu cầu xã hội và nhu cầu của Ngành thông tin và truyền thông Việt Nam.";
            DaoTao = "Hệ thống đào tạo và cấp bằng của Học viện bao gồm nhiều cấp độ tuỳ thuộc vào thời gian đào tạo và chất lượng đầu vào của các học viên. Hiện nay Học viện cung cấp các dịch vụ giáo dục, đào tạo chủ yếu sau đây:\r\n\r\nThực hiện các khoá đào tạo bậc Cao đẳng, Đại học, Thạc sĩ và Tiến sĩ theo chương trình chuẩn quốc gia và quốc tế theo các hình thức khác nhau như tập trung, phi tập trung, liên thông, đào tạo từ xa…\r\nTổ chức các khoá đào tạo bồi dưỡng ngắn hạn cấp chứng chỉ trong các lĩnh vực Bưu chính, Viễn thông, công nghệ thông tin, quản trị kinh doanh, an toàn thông tin, công nghệ đa phương tiện…\r\nTổ chức các chương trình đào tạo cho nước thứ ba.\r\nSẵn sàng liên danh, liên kết với các đối tác trong nước và quốc tế trong lĩnh vực giáo dục, đào tạo.";
            NghienCuu = "Tổ chức nghiên cứu về chiến lược, quy hoạch phát triển mạng và dịch vụ bưu chính, viễn thông và công nghệ thông tin.\r\nTổ chức nghiên cứu về công nghệ, giải pháp và phát triển dịch vụ trong lĩnh vực bưu chính, viễn thông và công nghệ thông tin. Tổ chức nghiên cứu và phát triển các sản phẩm, bán sản phẩm trong lĩnh vực điện tử – viễn thông. Tổ chức nghiên cứu về quản lý, điều hành doanh nghiệp và các lĩnh vực kinh tế khác.\r\nCung cấp các dịch vụ tư vấn về công nghệ, giải pháp và phát triển dịch vụ trong lĩnh vực bưu chính, viễn thông, công nghệ thông tin và lĩnh vực kinh tế cho các đơn vị trong và ngoài Ngành thông tin và truyền thông  Việt Nam.\r\nCung cấp các dịch vụ đo lường, kiểm chuẩn, tư vấn thẩm định các công trình, dự án thuộc lĩnh vực bưu chính viễn thông và công nghệ thông tin.\r\nHọc viện được ký thoả ước hợp tác với các tổ chức nghiên cứu và đào tạo nước ngoài, trao đổi chuyên gia nghiên cứu và đào tạo với nước ngoài theo quy định của Nhà nước.";
            DiaChi = "Trụ sở chính:\r\n122 Hoàng Quốc Việt, Q.Cầu Giấy, Hà Nội.\r\n\r\nCơ sở đào tạo tại Hà Nội:\r\nKm10, Đường Nguyễn Trãi, Q.Hà Đông, Hà Nội";
        }

        public void GotoPage(string page)
        {
            NavigatetoPage(page);
        }

        public async void NavigatetoPage(string page)
        {
            await NavigationService.NavigateAsync(page);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
