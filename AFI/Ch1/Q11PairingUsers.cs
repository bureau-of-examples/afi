using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions.Ch1
{
    /// <summary>
    /// Match users whose attributes are the same (order doesn't matter).
    /// </summary>
    public static class Q11PairingUsers
    {
        public static IList<UserPair> PairUsersExact(IList<User> users)
        {
            var unpaired = new Dictionary<User, User>();
            var paired = new List<UserPair>();

            for (int i = 0; i < users.Count; i++)
            {
                if (unpaired.ContainsKey(users[i]))
                {
                    paired.Add(new UserPair(unpaired[users[i]], users[i]));
                    unpaired.Remove(users[i]);
                }
                else
                {
                    unpaired.Add(users[i], users[i]);
                }
            }

            return paired;
        }

        public class User
        {
            private static int NEXT_ID = 1;

            public static User Create(String[] attributes)
            {
                if (attributes == null)
                    throw new ArgumentNullException();

                return new User(NEXT_ID++, attributes);
            }

            private User(int id, String[] attributes)
            {
                this.Id = id;
                this.Attributes = attributes;
                SortAttributes();
            }

            private void SortAttributes()
            {
                for (int i = 1; i < Attributes.Length; i++)
                {
                    String temp = Attributes[i];
                    int j = i - 1;
                    while (j >= 0 && Attributes[j].CompareTo(temp) > 0)
                    {
                        Attributes[j + 1] = Attributes[j];
                        j--;
                    }
                    Attributes[j + 1] = temp;
                }
            }

            public int Id
            {
                get;
                private set;
            }

            public String[] Attributes
            {
                get;
                private set;
            }

            public override bool Equals(object obj)
            {
                User that = obj as User;
                if (that == null)
                    return false;

                if (this.Attributes.Length != that.Attributes.Length)
                    return false;

                for (int i = 0; i < this.Attributes.Length; i++)
                {
                    if (this.Attributes[i] != that.Attributes[i])
                        return false;
                }
                return true;
            }

            public override int GetHashCode()
            {
                int hashCode = 0;
                for (int i = 0; i < this.Attributes.Length; i++)
                {
                    hashCode ^= this.Attributes[i].GetHashCode();
                }
                return hashCode;
            }
        }

        public struct UserPair
        {
            public UserPair(User user1, User user2) 
            {
                this.user1 = user1;
                this.user2 = user2;
            }

            private User user1;
            private User user2;

            public User User1
            {
                get
                {
                    return user1;
                }
            }

            public User User2
            {
                get
                {
                    return user2;
                }
            }
        }
    }
}
