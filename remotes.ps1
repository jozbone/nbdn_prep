("ranger001","pconway","stpremkumar","jozbone") | foreach-object{
  git remote add $_ git://github.com/$_/nbdn_prep.git
}

