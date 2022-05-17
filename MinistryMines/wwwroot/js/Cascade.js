$(document).ready(function () {
    console.log('success');
    GetTitle();
    GetState();
    $('#txtstate_1').change(function () {
        var id = $(this).val();
        $('#txtdistrict_1').empty();
        $('#txtdistrict_1').append('<Option>---Select State--</Option>');
        $.ajax({
            url: '/User/DistrictAction?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    console.log(result);
                    $('#txtdistrict_1').append('<Option value=' + data.district_Id + '>' + data.district_Name + '</Option>');
                })

            }
        });
    })



    GetState2();
    $('#txtstate_2').change(function () {
        var id = $(this).val();
        $('#txtdistrict_2').empty();
        $('#txtdistrict_2').append('<Option>---Select District--</Option>');
        $.ajax({
            url: '/User/DistrictAction2?id=' + id,
            success: function (result) {
                $.each(result, function (i, data)
                {
                    console.log(result);
                    $('#txtdistrict_2').append('<Option value=' + data.dis_Id + '>' + data.dis_Name + '</Option>');
                })
            }
        });
    })



    $('#sameadd').change(function () {
        debugger;
        if (this.checked) {
            //var returnVal = confirm("Are you sure?");
            let state = $('#txtstate_1').val();
            $('#txtstate_2').val(state)
            let address = $('#txtaddress1').val();
            $('#txtaddress2').val(address)
        }

    });

});


function GetTitle() {
    $.ajax({
        url: '/User/TilteAction',
        success: function (result) {
            //debugger;
            console.log(result);
            $.each(result, function (i, data) {
                $('#txttitle').append('<Option  Value=' + data.id + '>' + data.titleName + '</Option>');
            });
        }
    });
}


function GetState() {
    $.ajax({
        url: '/User/StateAction',
        success: function (result) {
            debugger;
            console.log(result);
            $.each(result, function (i, data) {
                $('#txtstate_1').append('<Option  Value=' + data.state_Id + '>' + data.st_Name + '</Option>');
            });
        }
    });

}


function GetState2() {
    $.ajax({
        url: '/User/StateAction2',
        success: function (result) {
            debugger;
            console.log(result);
            $.each(result, function (i, data) {
                $('#txtstate_2').append('<Option  Value=' + data.s_Id + '>' + data.state_Name + '</Option>');
            });
        }
    });
}





function GetDistrict2() {
    $.ajax({
        url: '/User/DistrictAction2',
        success: function (result) {
            debugger;
            console.log(result);
            $.each(result, function (i, data) {
                $('#txtdistrict_1').append('<Option  Value=' + data.dis_Id + '>' + data.dis_Name + '</Option>');
            });
        }
    });
}


function ValidateEmail()
{
    var email = document.getElementById("txtEmail").value;
    var address = document.getElementById("txtaddress1").value;
    //var nme = document.getElementById("txtEmail").value;
    var lblError = document.getElementById("lblError");
    var lblErroraddr = document.getElementById("lblError");
    lblError.innerHTML = "";
    var expr = /^([\w-\.]+)@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    var addr = /^([a-zA-Z0-9_\.\-])$/;
    //var nme = /^([\w-\.]+)@@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;

    if (!expr.test(email))
    {
        lblError.innerHTML = "Invalid email address.";
    }
    else if (!expr.test(address))
    {
        lbladd1Error.innerHTML = "Invalid  address format";
    }








}
