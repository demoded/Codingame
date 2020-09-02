Convert.ToString(n, 2)
Convert.ToString(n, 8)
Convert.ToString(n, 16)

//count total number of the same charachter in line //100020300001 -> 8
return s.ToCharArray().OrderBy(o => o).GroupBy(g => g).OrderByDescending(oo => oo.Count()).FirstOrDefault().Count();

//find longest consequtive group of '0'  //100020300001 -> 4
return N.Split("123456789".ToCharArray()).OrderByDescending(o => o.Count()).FirstOrDefault().Count();


