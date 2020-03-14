## Git Commands

    git clone https://github.com/nuboid/sbmcourse.git
    git status
    git add .
    git commit -a -m "test"
    git push
    git branch
    git branch "myfeature"
    git checkout "myfeature"
    git push origin "myfeature"
    git push --set-upstream origin "myfeature"
    git push
    
Typical workflow

	git branch "branchname"
	git status
	git branch -a
	git checkout "branchname"
	git push --set-upstream origin "branchname"
	//develop ...
	git add .
	git commit -a -m "commitmessage"
	git push origin

Checkout from a commit
   
    git checkout 78298273b50fe5be33d9596d6e7e9fa65d4f1895

See all branches

	git branch -a

Delete branches

	git branch -d "branchname"
	git push origin --delete "branchname"
	
**Git UI tooling**

[https://www.syntevo.com/smartgit/](https://www.syntevo.com/smartgit/)

[https://www.gitkraken.com/](https://www.gitkraken.com/)

[https://www.sourcetreeapp.com/](https://www.sourcetreeapp.com/)

[https://tortoisegit.org/](https://tortoisegit.org/)
<!--stackedit_data:
eyJoaXN0b3J5IjpbLTE1OTIzNDMwMDJdfQ==
-->