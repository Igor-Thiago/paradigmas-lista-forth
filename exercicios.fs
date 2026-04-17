variable tmp-flag
variable tmp-n
create tmp-buf 1024 cells allot
variable tmp-count

: sort-two 2dup > if swap then ;

: sort-three
	>r
	sort-two
	r>
	sort-two
	>r
	sort-two
	r>
;

: dots 0 do [char] . emit loop ;

: ** ( base expoente -- resultado )
	1 swap 0 ?do
		over *
	loop
	nip
;

: 3dup 2 pick 2 pick 2 pick ;

: put roll ;

: reverse
	dup tmp-n !
	drop
	tmp-n @ 0 ?do
		i pick
		i cells tmp-buf + !
	loop
	tmp-n @ 0 ?do drop loop
	tmp-n @ 0 ?do
		i cells tmp-buf + @
	loop
;

: drop-many 0 ?do drop loop ;

: drop-at roll drop ;

: pop-at roll ;

: print-change
	100 /mod swap over . ." nota(s) de 100" cr swap drop
	50  /mod swap over . ." nota(s) de 50"  cr swap drop
	20  /mod swap over . ." nota(s) de 20"  cr swap drop
	10  /mod swap over . ." nota(s) de 10"  cr swap drop
	5   /mod swap over . ." nota(s) de 5"   cr swap drop
	2   /mod swap over . ." nota(s) de 2"   cr swap drop
	1   /mod swap over . ." moeda(s) de 1"  cr
	2drop
;

: max-n 1- 0 ?do max loop ;

: reset depth 0 do drop loop ;

: all-positive
	-1 tmp-flag !
	depth 0 ?do
		dup 0< if
			0 tmp-flag !
		then
		drop
	loop
	tmp-flag @
;

: all-sorted
	depth tmp-n !
	tmp-n @ 1 <= if
		tmp-n @ 0 ?do drop loop
		-1 exit
	then

	-1 tmp-flag !
	tmp-n @ 1- 0 ?do
		i 1+ pick i pick > if
			0 tmp-flag !
		then
	loop

	tmp-n @ 0 ?do drop loop
	tmp-flag @
;

: filter-positive
	depth tmp-n !
	0 tmp-count !

	tmp-n @ 0 do
		tmp-n @ 1- i - pick
		dup 0>= if
			tmp-count @ cells tmp-buf + !
			1 tmp-count +!
		else
			drop
		then
	loop

	tmp-n @ 0 do drop loop

	tmp-count @ 0 do
		i cells tmp-buf + @
	loop
;