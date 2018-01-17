function leapYear(year) {
    let leap = (year % 2 == 0 && year % 100 != 0) ||
      (year % 400 == 0);
    console.log(leap ? "yes" : "no");
  }

  leapYear(1990);