//Leetcode 2043. Simple Bank System med
//题意：你被委托编写一个程序，用于一家流行银行，将其所有进账事务（转账、存款和取款）自动化。
//银行有 n 个帐户，编号从 1 到 n。每个帐户的初始余额存储在一个从 0 开始索引的整数数组 balance 中，第 (i + 1) 个帐户的初始余额为 balance[i]。
//执行所有有效的交易。如果交易是有效的，则满足以下条件：
//给定的帐户编号在 1 到 n 之间。
//从中取款或转账的金额不超过帐户的余额。
//实现 Bank 类：
//Bank(long[] balance) 使用从 0 开始索引的整数数组 balance 初始化对象。
//boolean transfer(int account1, int account2, long money) 从编号为 account1 的帐户转账 money 美元到编号为 account2 的帐户。如果交易成功，返回 true，否则返回 false。
//boolean deposit(int account, long money) 将 money 美元存入编号为 account 的帐户。如果交易成功，返回 true，否则返回 false。
//boolean withdraw(int account, long money) 从编号为 account 的帐户取款 money 美元。如果交易成功，返回 true，否则返回 false。
//思路：hashtable 看code
//时间复杂度：O(1)
//空间复杂度：O(1)
        public class Bank
        {

            long[] accBalance;
            int n;

            public Bank(long[] balance)
            {
                accBalance = balance.ToArray();
                n = balance.Length;
            }

            public bool Transfer(int account1, int account2, long money)
            {
                if (!ValidAccount(account1) || !ValidAccount(account2)
                    || accBalance[account1 - 1] < money)
                {
                    return false;
                }

                accBalance[account1 - 1] -= money;
                accBalance[account2 - 1] += money;

                return true;
            }

            public bool Deposit(int account, long money)
            {
                if (!ValidAccount(account))
                    return false;

                accBalance[account - 1] += money;

                return true;
            }

            public bool Withdraw(int account, long money)
            {
                if (!ValidAccount(account) || accBalance[account - 1] < money)
                    return false;

                accBalance[account - 1] -= money;

                return true;
            }

            private bool ValidAccount(int account)
            {
                return (account >= 1 && account <= n);
            }
        }