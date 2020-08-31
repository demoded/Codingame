Convert.ToString(n, 2)
Convert.ToString(n, 8)
Convert.ToString(n, 16)

var a = s.ToCharArray().OrderBy(o => o).GroupBy(g => g).OrderByDescending(oo => oo.Count());

