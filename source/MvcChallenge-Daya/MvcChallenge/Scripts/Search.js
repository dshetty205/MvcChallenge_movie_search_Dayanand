var handler = function () {
    if ($('#titleId').val().length == 0) {
        if ($('#txtTitleName').val().length == 0)
            alert("Enter movie name");
        else {
            alert("Select movie name from autocomplete...");
        }
    } else {
        $("#btnSearch").off("click", handler);
        $("#showTitleDetailsDiv").hide();
        $('#loading').show();
        var url = '/Home/ShowTitleDetails?titleId=' + $('#titleId').val();
        $.get(url, null, function (data) {
            $("#showTitleDetailsDiv").html(data);
            $('div.expander').expander();
            $('#loading').hide();
            $("#showTitleDetailsDiv").show();
        });
    }
};
$("#btnSearch").on("click", handler);

$("#txtTitleName").typeahead({
    source: function (query, process) {
        $('#titleId').val('');

        $("#btnSearch").off("click", handler);
        $("#btnSearch").on("click", handler);

        var countries = [];
        map = {};
        return $.post('/Home/TitlesLookup', { query: query }, function (data) {
            $.each(data, function (i, titles) {
                map[titles.TitleName] = titles;
                countries.push(titles.TitleName);
            });
            process(countries);
        });
    },
    updater: function (item) {
        var selectedTitleId = map[item].TitleId;
        $("#titleId").val(selectedTitleId);
        $("#btnSearch").click();
        return item;
    }
});
