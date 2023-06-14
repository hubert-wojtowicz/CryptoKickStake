// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

contract BettingContract {
    struct Betting {
        address user;
        uint256 amount;
        uint256 resultOption;
    }

    struct Event {
        uint256 startTime;
        uint256 duration;
        bool finished;
        uint256 winningResultOption;
    }

    mapping(uint256 => Event) public events;
    mapping(uint256 => Betting[]) public eventBets;
    mapping(address => uint256) public userBalances;

    uint256 public eventId;
    uint256 public provision;

    // Function to create a new event
    function createEvent(uint256 _startTime, uint256 _duration) external {
        events[eventId] = Event(_startTime, _duration, false, 0);
        eventId++;
    }

    // Function to place a bet on an event
    function placeBet(uint256 _eventId, uint256 _resultOption) external payable {
        require(block.timestamp < events[_eventId].startTime, "Event has already started");
        require(!events[_eventId].finished, "Event has already finished");

        eventBets[_eventId].push(Betting(msg.sender, msg.value, _resultOption));
        userBalances[address(this)] += msg.value;
    }

    // Function to determine the winning result option and distribute the stakes
    function determineWinner(uint256 _eventId, uint256 _winningResultOption) external {
        require(block.timestamp >= events[_eventId].startTime + events[_eventId].duration, "Event is still ongoing");
        require(!events[_eventId].finished, "Event has already finished");

        events[_eventId].finished = true;
        events[_eventId].winningResultOption = _winningResultOption;

        uint256 totalStake = userBalances[address(this)];
        uint256 winningStake = 0;

        for (uint256 i = 0; i < eventBets[_eventId].length; i++) {
            Betting storage bet = eventBets[_eventId][i];
            if (bet.resultOption == _winningResultOption) {
                winningStake += bet.amount;
                userBalances[bet.user] += bet.amount;
            }
        }

        if (winningStake > 0) {
            uint256 proportionalShare = (winningStake * totalStake) / winningStake;
            userBalances[address(this)] -= proportionalShare;
        }

        provision += winningStake;
    }

    // Function to withdraw ETH if the user's bet was correct
    function withdraw(uint256 _eventId) external {
        require(events[_eventId].finished, "Event is still ongoing");
        require(events[_eventId].winningResultOption > 0, "Winning result option not determined");
        require(userBalances[msg.sender] > 0, "No balance to withdraw");

        uint256 amountToWithdraw = userBalances[msg.sender];
        userBalances[msg.sender] = 0;
        payable(msg.sender).transfer(amountToWithdraw);
    }

    // Function to check the user's betting history
    function getBettingHistory(uint256 _eventId) external view returns (Betting[] memory) {
        return eventBets[_eventId];
    }
}