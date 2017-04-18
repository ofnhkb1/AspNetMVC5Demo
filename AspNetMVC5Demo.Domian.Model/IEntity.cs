namespace AspNetMVC5Demo.Domian.Model
{
    /// <summary>
    /// 标记为实体
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }

    /// <summary>
    /// 标记为实体
    /// </summary>
    public class EntityBase : IEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 返回该对象的字符串文本
        /// </summary>
        public override string ToString() => $"Entity {this.Id}";

        /// <summary>
        /// return 1
        /// </summary>
        public override int GetHashCode() => 1;

        /// <summary>
        /// 判断两个实体是否为同一个实体
        /// </summary>
        public override bool Equals(object obj)
        {
            EntityBase other = obj as EntityBase;
            if (other == null)
            {
                return false;
            }

            return object.ReferenceEquals(this, other)
                   && this.Id == other.Id;
        }

        public static bool operator !=(EntityBase left, EntityBase right) => !(left == right);

        public static bool operator ==(EntityBase left, EntityBase right)
        {
            if ((object)left == null && (object)right == null)
            {
                return true;
            }
            if ((object)left == null)
            {
                return false;
            }
            if ((object)right == null)
            {
                return false;
            }

            return object.ReferenceEquals(left, right)
                   && left.Id == right.Id;
        }
    }
}