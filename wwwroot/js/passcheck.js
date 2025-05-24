function calculatePasswordStrength(password) {
    let score = 0;
    if (!password) return score;

    if (password.length >= 8) score += 1;
    if (password.match(/[a-z]/)) score += 1;
    if (password.match(/[A-Z]/)) score += 1;
    if (password.match(/[0-9]/)) score += 1;
    if (password.match(/[^a-zA-Z0-9]/)) score += 1;

    return score;
}

function updateStrengthBar(score) {
    const bar = $("#passwordStrengthBar");
    bar.removeClass("bg-danger bg-warning bg-info bg-success");

    let label = "Weak";
    let width = "20%";

    if (score <= 1) {
        bar.addClass("bg-danger");
        label = "Weak";
        width = "20%";
    } else if (score == 2) {
        bar.addClass("bg-warning");
        label = "Fair";
        width = "40%";
    } else if (score == 3 || score == 4) {
        bar.addClass("bg-info");
        label = "Strong";
        width = "70%";
    } else if (score == 5) {
        bar.addClass("bg-success");
        label = "Very Strong";
        width = "100%";
    }

    bar.css("width", width);
    bar.text(label);
}

$(document).ready(function () {
    $("#passwordInput").on("input", function () {
        const password = $(this).val();
        const score = calculatePasswordStrength(password);
        updateStrengthBar(score);
    });
});