'use strict';

tnttApp.filter('miens', function () {
    return function(mienId) {
        switch (mienId) {
        case 1:
            return "Miền Tây Bắc";
        case 2:
            return "Miền Tây";
        case 3:
            return "Miền Tây Nam";
        case 4:
            return "Miền Nam";
        case 5:
            return "Miền Trung";
        case 6:
            return "Miền Trung Đông";
        case 7:
            return "Miền Đông Bắc";
        case 8:
            return "Miền Đông Nam";
        }
    }
});

tnttApp.filter('roles', function () {
    return function(role) {
        switch (role) {
        case 1:
            return "Tuyên Úy";
        case 2:
            return "Trợ Úy";
        case 3:
            return "Trợ Tá";
        case 4:
            return "Huynh Trưởng";
        case 5:
            return "Huấn Luyện Viên";
        }
    }
});
