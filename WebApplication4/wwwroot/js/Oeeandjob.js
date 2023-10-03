const numbers = [1, 2, 3, 4, 5, 6, 7];
function gradientcolor(ctx) {
    var background_1 = ctx.createLinearGradient(0, 0, 0, 600);
    background_1.addColorStop(0, 'darkblue');
    background_1.addColorStop(1, 'white');
    return background_1;
}



$.each(numbers, function (index, value) {
    console.log(value);
    var chartnum = ("barchartB" + value.toString());
    var ctx = document.getElementById(chartnum).getContext('2d');
    console.log(chartnum);


    var data = {
        datasets: [{
            data: [10, 20, 30],
            backgroundColor: [
                '#3c8dbc',
                '#f56954',
                '#f39c12',
            ],
        }],
        labels: [
            'Request',
            'Layanan',
            'Problem'
        ]
    };
    var myDoughnutChart_2 = new Chart(ctx, {
        type: 'bar',
        data: data,
        options: {
            responsive: false,
            maintainAspectRatio: false,
            legend: {
                position: 'bottom',
                labels: {
                    boxWidth: 12
                }
            }
        }
    });
});