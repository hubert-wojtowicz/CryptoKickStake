# Requirements

# Definitions

*__Event__* is competition between two or more *__Parties__* that starts at *__Start Time__* and ends within specific *__Duration__* leading to one *__Result__* out of many possible *__Result Options__*. 

*__Users__* can pick one of many *__Result Options__* and send *__Contribution__* to *__Stake__* sending amouth of Ether(ETH). This *__User__* activity is called *__Betting__*.

*__Betting__* can be done one or more time by *__User__* to the same *__Event__* before *__Start Time__* of *__Event__*.

Each *__Betting__* has additional behind called *__Provision__*. *__Provision__* is used to maintain product as well as pay gas for execution in Etherum blockchain. 

*__Betting__* activitiy present to *__User__* predicted *__Prize__* assuming picking *__Result Option__*.

After specified *__Duration__* of *__Event__* (plus some small delay) *__Result__* is known. This means *__Event__* is in *__Finished State__*.

*__User__* can *__Withdraw__* ETH from contract if he picked right *__Result Option__* and *__Event__* is in *__Finished State__*.

*__Stake__* is sharred proportianally among *__Users__* having in regard *__Contribution__* amount to *__Stake__*.

*__User__* can see all past *__Betting__* history as this is public and transparent.


# Technical consideration

## On-chain 
All data related to *__User__* decisions for transparency, immutablity and secuiry will be stored in blockchain.
User interface will communicate only with Solidity contracts via web3 library.

## Off-chain
We will spin up .NET application that will communicate with third party API sourcing in reasonable way (cache) information about upcomming *__Events__* and *__Results__*.

This application will :
- store upcomming *__Events__* to blockchain making them availiable to *__Users__*.
- store result of *__Event__* to blockchain making possible *__Withdraw__* to *__Users__*.

## Problems
1. How to verify that address is blockchain user?
  