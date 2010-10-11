[ "ranger001","pconway","stpremkumar","jozbone" ].each do |name|
  `git remote add #{name} git://github.com/#{name}/nbdn_prep.git`
end
