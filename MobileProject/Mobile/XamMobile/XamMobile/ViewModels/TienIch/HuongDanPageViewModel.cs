using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using XamMobile.Services.Interface;

namespace XamMobile.ViewModels.TienIch
{
    public class HuongDanPageViewModel : ViewModelBase
    {
        private string _thongBao;
        public string ThongBao
        {
            get { return _thongBao; }
            set
            {
                if (_thongBao != value)
                {
                    _thongBao = value;
                    OnPropertyChanged(nameof(ThongBao));
                }
            }
        }

        private string _ungDung;
        public string UngDung
        {
            get { return _ungDung; }
            set
            {
                if (_ungDung != value)
                {
                    _ungDung = value;
                    OnPropertyChanged(nameof(UngDung));
                }
            }
        }
        private string _caiDat;
        public string CaiDat
        {
            get { return _caiDat; }
            set
            {
                if (_caiDat != value)
                {
                    _caiDat = value;
                    OnPropertyChanged(nameof(CaiDat));
                }
            }
        }
        private string _linkDuongDan;
        public string LinkDuongDan
        {
            get { return _linkDuongDan; }
            set
            {
                if (_linkDuongDan != value)
                {
                    _linkDuongDan = value;
                    OnPropertyChanged(nameof(LinkDuongDan));
                }
            }
        }

        IUserService iUserService;

        public HuongDanPageViewModel(INavigationService navigationService, IUserService iUserService) : base(navigationService)
        {
            this.iUserService = iUserService;
            ThongBao = "Thực hiện kế hoạch, phương án chuyển đổi số Học viện đến năm 2025. Nhằm tạo điều kiện hỗ trợ công tác quản lý đào tạo tại cơ sở đào tạo Hà Nội; Hỗ trợ giảng viên, sinh viên trong quá trình giảng dạy, học tập, rèn luyện tại Học viện. Học viện thông báo triển khai thử nghiệm ứng dụng PTIT S-Link tại cơ sở đào tạo Hà Nội như sau:";
            UngDung = "– Ứng dụng PTIT S-Link được Học viện đặt hàng xây dựng và triển khai với mong muốn hỗ trợ giảng viên, sinh viên của Học viện trong quá trình giảng dạy, học tập, rèn luyện. Ứng dụng được cài đặt và sử dụng trên  các thiết bị smartphone với các tính năng triển khai trong giai đoạn thử nghiệm:\r\n\r\n– Cung cấp tin tức liên quan đến quản lý đào tạo. Cập nhật, thông  báo các sự kiện chung của Học viện.\r\n\r\n– Thời khóa biểu (lịch học, lịch thi) theo tháng, theo tuần, ngày, theo danh sách các công việc cần thực hiện cho từng cá nhân.\r\n\r\n– Góc học tập tổng hợp các thông tin về điểm tích lũy, điểm thi các môn, số lượng tín chỉ tích lũy, tình trạng học tập của sinh viên…\r\n\r\n– Quản lý thông tin các lớp hành chính cho sinh viên, giảng viên cố vấn học tập.\r\n\r\n – Thực hiện việc khảo sát trực tuyến đối với sinh viên…\r\n\r\n– Tiếp nhận, trả lời các phản hồi từ người dùng (sinh viên/giảng viên/cánbộ) tới Học viện.\r\n\r\n– Cung cấp môi trường tương tác, thông báo giữa giảng viên, sinh viên theo lớp chính khóa, lớp học phần…\r\n\r\n– Trong thời gian tới, các tính năng sẽ triển khai: cung cấp, thực hiện các dịch vụ hành chính đối với sinh viên. Thông tin quản lý, thanh toán học phí, lệ phí và các dịch vụ khác trực tuyến.";
            CaiDat = "–  Các thiết bị Smartphone sử dụng hệ điều hành iOS/Android: trong App Store/CH Play người dùng tìm và cài đặt ứng dụng PTIT S-Link.\r\n\r\n– Giảng viên và sinh viên đăng nhập và sử dụng ứng dụng PTIT S-Link bằng tài khoản (Tên đăng nhập/mật khẩu) tương ứng trong hệ thống quản lý đào tạo của Học viện.";
            LinkDuongDan = "https://portal.ptit.edu.vn/wp-content/uploads/2021/01/HDSD-HSSV-Ptit.pdf";
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
